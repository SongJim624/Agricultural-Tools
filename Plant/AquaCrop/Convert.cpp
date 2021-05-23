#include <iostream>
#include <fstream>
#include <string>
#include "Plant.h"

void Node(const std::string& name, const std::string& value, TiXmlElement* parent, const std::string& type = "float")
{
	TiXmlElement* node = new TiXmlElement("Parameter");
	node->SetAttribute("type", type.c_str());
	node->SetAttribute("size", "single");

	TiXmlElement* name_node = new TiXmlElement("name");
	name_node->LinkEndChild(new TiXmlText(name.c_str()));
	node->LinkEndChild(name_node);

	TiXmlElement* value_node = new TiXmlElement("value");
	value_node->LinkEndChild(new TiXmlText(value.c_str()));
	node->LinkEndChild(value_node);

	parent->LinkEndChild(node);
}

int Day_Cal(int year, int month, int day)
{
	std::map<int, double> table = {};
	table[1] = 0.0;
	table[2] = 31.0;
	table[3] = 59.25;
	table[4] = 90.25;
	table[5] = 120.25;
	table[6] = 151.25;
	table[7] = 181.25;
	table[8] = 212.25;
	table[9] = 243.25;
	table[10] = 273.25;
	table[11] = 304.25;
	table[12] = 334.25;

	return int(floor((year - 1901.0) * 365.25 + table[month] + day));
}

void AquaCrop_Plant:: Convert(const char * file_path, const char * xml_path)
{
	std::fstream file(file_path);

	TiXmlDocument doc = TiXmlDocument();
	TiXmlElement* root = new TiXmlElement("Parameters");
	doc.LinkEndChild(root);

	std::string s;

//Phenomena
	TiXmlElement* pheno = new TiXmlElement("section");
	pheno->SetAttribute("name", "Phenomena");
	root->LinkEndChild(pheno);

	std::getline(file, s); // Comment
	std::getline(file, s); // Phenomena

	int day, month, year;
	file >> day; std::getline(file, s);
	file >> month; std::getline(file, s);
	file >> year; std::getline(file, s);
	Node("sowingdate", std::to_string(Day_Cal(year, month, day)), pheno, "integer");

	std::getline(file, s, '\t');
	Node("Tbase", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("Tupper", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("TS2E", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("TS2R", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("TS2F", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("TS2S", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("TS2M", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("FL", s, pheno);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("build", s, pheno);
	std::getline(file, s);

//Canopy
	TiXmlElement* canopy = new TiXmlElement("section");
	canopy->SetAttribute("name", "Canopy");
	root->LinkEndChild(canopy);

	std::getline(file, s); //Canopy
	float CCo = 0.0, PD = 0.0;

	file >> CCo;  std::getline(file, s);
	file >> PD;  std::getline(file, s);
	Node("CCo", std::to_string(0.00000001 * CCo * PD), canopy);

	std::getline(file, s, '\t');
	Node("CCx", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("CGC", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("CDC", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("kcbtrx", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("fage", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("fdecline", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("alpha", s, canopy);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("beta", s, canopy);
	std::getline(file, s);

//Root
	TiXmlElement* root_node = new TiXmlElement("section");
	root_node->SetAttribute("name", "Root");
	root->LinkEndChild(root_node);

	std::getline(file, s);//Root

	std::getline(file, s, '\t');
	Node("Zo", s, root_node);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("Zx", s, root_node);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_root", s, root_node);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_proot", s, root_node);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SxTop", s, root_node);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SxBot", s, root_node);
	std::getline(file, s);

//Biomass
	TiXmlElement* biomass = new TiXmlElement("section");
	biomass->SetAttribute("name", "Biomass");
	root->LinkEndChild(biomass);

	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("WP", s, biomass);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("sink", s, biomass);
	std::getline(file, s);

	std::getline(file, s, '\t');			// Crop performance under elevated atmospheric CO2 concentration(%)
	Node("fyield", s, biomass);
	std::getline(file, s);

//Yield
	TiXmlElement* yield = new TiXmlElement("section");
	yield->SetAttribute("name", "Yield");
	root->LinkEndChild(yield);

	std::getline(file, s);//Yield

	std::getline(file, s, '\t');
	Node("HIo", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("dHImax", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("dHIante", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("fexcess", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("a", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("b", s, yield);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("CC_remain", s, yield);
	std::getline(file, s);

//Water Stress
	TiXmlElement* water_str = new TiXmlElement("section");
	water_str->SetAttribute("name", "Water Stress");
	root->LinkEndChild(water_str);

	std::getline(file, s);//water stress

	std::getline(file, s, '\t');
	Node("ztop", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("fadj", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_exp_upper", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_exp_lower", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_exp", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_sto_upper", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_sto", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_sen_upper", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_sen", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_pol_upper", s, water_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("w_aer_upper", s, water_str);
	std::getline(file, s);

//Fertiles Stress
	TiXmlElement* fert_str = new TiXmlElement("section");
	fert_str->SetAttribute("name", "Water Stress");
	root->LinkEndChild(fert_str);

	std::getline(file, s);//fertile stress

	std::getline(file, s, '\t');
	Node("ksf_CCx", s, fert_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_ksf_exp", s, fert_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_ksf_CCx", s, fert_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_WP", s, fert_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("SF_ksf_sen", s, fert_str);
	std::getline(file, s);

//Heat Stress
	TiXmlElement* heat_str = new TiXmlElement("section");
	heat_str->SetAttribute("name", "Heat Stress");
	root->LinkEndChild(heat_str);

	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("c_pol", s, heat_str);
	std::getline(file, s);

    std::getline(file, s, '\t');
	Node("h_pol", s, heat_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("c_sto", s, heat_str);
	std::getline(file, s);

//salt stress
	TiXmlElement* salt_str = new TiXmlElement("section");
	salt_str->SetAttribute("name", "Water Stress");
	root->LinkEndChild(salt_str);

	std::getline(file, s);//salt stress

	std::getline(file, s, '\t');
	Node("So", s, salt_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("Sx", s, salt_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("kss_CCx", s, salt_str);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("kss_sto", s, salt_str);
	std::getline(file, s);

//Initial Condition
	std::getline(file, s);
	TiXmlElement* initial = new TiXmlElement("section");
	initial->SetAttribute("name", "Heat Stress");
	root->LinkEndChild(initial);

	std::getline(file, s, '\t');
	Node("crop growth time", s, initial);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("canopy cover", s, initial);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("root depth", s, initial);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("biomass", s, initial);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("harvest index", s, initial);
	std::getline(file, s);

	std::getline(file, s, '\t');
	Node("yield", s, initial);
	std::getline(file, s);

	doc.SaveFile(xml_path);
	return;
}