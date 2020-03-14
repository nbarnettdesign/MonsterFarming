using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentExpManager : MonoBehaviour
{
    public List<CharacterEXPstats> charactersList;
    public List<WeaponEXPstats> weaponsList;
    public List<ArmorEXPstats> armorsList;
    public List<BagEXPstats> bagsList;
    public List<ConsumableEXPstats> consumablesList;
    public List<EnvironmentEXPstats> environmentsList;




}

[System.Serializable]
public class CharacterEXPstats //100-199
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}
[System.Serializable]
public class WeaponEXPstats //200-299
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}
[System.Serializable]
public class ArmorEXPstats //300-399
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}
[System.Serializable]
public class BagEXPstats //400-499
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}
[System.Serializable]
public class ConsumableEXPstats //500-599
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}
[System.Serializable]
public class EnvironmentEXPstats //600-699
{
    public int ID;
    public string Name;
    public string Skill1;
    public int Exp1;
    public string Skill2;
    public int Exp2;
    public string Skill3;
    public int Exp3;
}