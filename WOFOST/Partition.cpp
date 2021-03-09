void Partition(const float& dt)
{
//time step DELT in the WOFOST code, dt in this codes

    float WLV = 0, WRT = 0, WST = 0, WSO = 0, TADW = 0;

    WRT += GWRT * dt;
    WST += GWST * dt;
    WSO += GWSO * dt;
    TADW += WLV + WST + WSO;


}