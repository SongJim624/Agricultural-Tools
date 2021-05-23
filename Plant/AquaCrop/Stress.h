#include "../Information.h"

#ifndef _STRESS_
#define _STRESS_
template<typename T>
class Stress
{
private:
    const T Sn = 0.01;
    const T Sx = 1.0;
//Parameters
    const T ztop, fadj;
    const T w_exp_upper, w_exp_lower, SF_exp;
    const T w_sto_upper, SF_sto, w_sen_upper, SF_sen;
    const T w_pol_upper, w_aer_upper;
    const T h_pol, c_pol, c_sto;
//Dependencies
//    const T& GDD, &Tmax, &Tmin, &ETo, &RD;
//    const std::vector<T> &theta, &compart, & Sat, &FC, &PWP;
//Internal variables
    T dr, ksw_aer_value, kscsto, kscpol, kshpol, ETo;
    std::vector<T> ksw_sto_array_value, ksw_aer_array_value;
private:
    T Linear(const T& Srel)
    {
        if (Srel < 0.0) { return 1.0; }
        if (Srel > 1.0) { return 0.0; }
        return isnan(Srel) ? 1.0 : 1 - Srel;
    };

    T Convex(const T& Srel, const T& SF)
    {
        if (Srel > 1.0) { return 0.0; }
        if (Srel < 0.0) { return 1.0; }

        return 1.0 - (expf(Srel * SF) - 1.0) / (expf(SF) - 1.0);
    };

    T Logistic(const T& Srel)
    {
        if (Srel > 1.0) { return 0.0; }
        if (Srel < 0.0) { return 1.0; }

        T r_minus = 2.0 * logf((2.0 * Sn * Sx - Sn) / (Sx - Sn));
        return Sn * Sx / (Sn + (Sx - Sn) * expf(r_minus * (1.0 - Srel)));
    };

    T padj_Cal(const T& p, const T& ETo)
    {
        return max(0.0, min(1.0, p + fadj * (0.2 - 0.04 * ETo) * log10(10.0 - 9.0 * p)));
    }

    T Srel(const T& dr, const T& p_upper, const T& p_lower, const T& ETo)
    {
        T upper = padj_Cal(p_upper, ETo);
        T lower = padj_Cal(p_lower, ETo);
        return max(min((dr - upper) / (lower - upper), 1.0), 0.0);
    }

public:
    Stress(Parameter<T>& parameters)
        :
        //Parameters 
        ztop(parameters["ztop"]), fadj(parameters["fadj"]),
        w_exp_upper(parameters["w_exp_upper"]), w_exp_lower(parameters["w_exp_lower"]), SF_exp(parameters["SF_exp"]),
        w_sto_upper(parameters["w_sto_upper"]), w_sen_upper(parameters["w_sen_upper"]), SF_sto(parameters["SF_sto"]),
        w_pol_upper(parameters["w_pol_upper"]), w_aer_upper(parameters["w_aer_upper"]), SF_sen(parameters["SF_sen"]),
        h_pol(parameters["h_pol"]), c_pol(parameters["c_pol"]), c_sto(parameters["c_sto"]){}
      //Dependencies
      //  RD(states["root depth"]), theta(dependencies.Theta()), Tmin(dependencies.Tmin()), 
      //  Tmax(dependencies.Tmax()),GDD(dependencies.GDD()), ETo(dependencies.ETo()), 
      //  compart(dependencies.Compart()), Sat(dependencies.Sat()), FC(dependencies.FC()), PWP(dependencies.PWP()){}

    void Update(State<T>& states, Dependency<T>& depend)
    {
        T dr_root = 0, dr_top = 0, taw_root = 0, taw_top = 0;
        T dr_aer = 0, taw_aer = 0, length = 0;
        ETo = depend.ETo;

        for (size_t i = 0; i < depend.compart.size(); ++i)
        {
            T delta = max(min(depend.compart[i], ztop - length), 0.0);

            dr_top += delta * (depend.FC[i] - depend.theta[i]);
            taw_top += delta * (depend.FC[i] - depend.PWP[i]);

            delta = max(min(depend.compart[i], 0.1 * states["root depth"] - length), 0.0);

            dr_root += delta * (depend.FC[i] - depend.theta[i]);
            taw_root += delta * (depend.FC[i] - depend.PWP[i]);

            dr_aer += delta * (depend.Sat[i] - depend.theta[i]);
            taw_aer += delta * depend.Sat[i] * (1.0 - w_aer_upper);

            length += depend.compart[i];
        }

        dr = min(dr_top / taw_top, dr_root / taw_root);

        ksw_aer_value = dr_aer > taw_aer ? 1.0 : dr_aer / taw_aer;

        ksw_sto_array_value.resize(depend.compart.size());
        for (size_t i = 0; i < depend.theta.size(); ++i)
        {
            T drel = Srel((depend.FC[i] - depend.theta[i]) / (depend.FC[i] - depend.PWP[i]),
                w_sto_upper, 1.0, depend.ETo);
            ksw_sto_array_value[i] = SF_sto == 0.0 ? Linear(drel) : Convex(drel, SF_sto);
        }

        ksw_aer_array_value.resize(depend.theta.size());
        for (size_t i = 0; i < depend.theta.size(); ++i)
        {
            ksw_aer_array_value[i] = depend.theta[i] > depend.Sat[i] * w_aer_upper ? 
                (1.0 - depend.theta[i] / depend.Sat[i]) / (1.0 - 0.01 * w_aer_upper) : 1.0;
        }

        kscsto = depend.GDD < 0.0 ? 0.0 : depend.GDD > c_sto ? 1.0 :
            Logistic(1 - depend.GDD / c_sto);

        kshpol = depend.Tmax < h_pol ? 1.0 : depend.Tmax > h_pol + 5.0 ? 0.0 :
            Logistic(0.2 * (depend.Tmax - h_pol));

        kscpol = depend.Tmin > c_pol ? 1.0 : depend.Tmin < c_pol - 5.0 ? 0.0
            : Logistic(0.2 * (c_pol - depend.Tmin));

        return;
    }

    T ksw_exp()
    {
        T drel = Srel(dr, w_exp_upper, w_exp_lower, ETo);
        return SF_exp == 0.0 ? Linear(drel) : Convex(drel, SF_exp);
    }

    T ksw_sto()
    {
        T drel = Srel(dr, w_sto_upper, 1.0, ETo);
        return SF_sto == 0.0 ? Linear(drel) : Convex(drel, SF_sto);
    }

    T ksw_sen(const T& beta = 0.0)
    {
        T drel = Srel(dr, w_sen_upper, 1.0, ETo) * (1.0 - 0.01 * beta);
        return SF_sen == 0.0 ? Linear(drel) : Convex(drel, SF_sen);
    }

    T ksc_pol()
    {
        return kscpol;
    }

    T ksh_pol()
    {
        return kshpol;
    }

    //Need the orginal function 
    T ksc_sto()
    {
        return kscsto;
    }

    T ksw_pol()
    {
        return Linear(Srel(dr, w_pol_upper, 1.0, ETo));
    }

    T ksw_aer()
    {
        return ksw_aer_value;
    }

    std::vector<T> ksw_sto_array()
    {
        return ksw_sto_array_value;
    }

    std::vector<T> ksw_aer_array()
    {
        return ksw_aer_array_value;
    }

    T ksw_sto_root()
    {
        T drel = Srel(dr, 0.5 * (1 + w_sto_upper) , 0.0, ETo);
        return SF_sto == 0.0 ? Linear(drel) : Convex(drel, SF_sto);
    }

};
#endif //!_STRESS_
