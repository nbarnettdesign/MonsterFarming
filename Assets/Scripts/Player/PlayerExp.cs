using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
   /* public GameObject player;
    public static PlayerExp instance;
    public List<Skills> skillAdd;
    public Item absorbtionGear;
    public string skillAdded;
    public int expAdded;
    public List<Skills> allSkills;
    public int skeletonLevel = 0;
    public int humanLevel = 0;

    public GameObject slimeSkills;
    public GameObject skeletonSkills;
    public GameObject humanSkills;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for(int i = 0; i < allSkills.Count; i++)
            {
                uint id = allSkills[i].id;
                Skills n = allSkills.Find(m => m.id == id);
                if (n == null)
                {
                    continue;
                }
                n.exp += (int)Random.Range(100f,140f);
                LevelingUp(n);
            }
        }
    }

    private void Start()
    {
        instance = this;
    }


    public void Absorb(ItemPickup equipment)
    {
        absorbtionGear = equipment.item;
        skillAdd = absorbtionGear.skills;
        for (int i = 0; i < skillAdd.Count; i++)
        {
            uint id = skillAdd[i].id;
            Skills n = allSkills.Find(m => m.id == id);
            if (n == null)
            {
                continue;
            }
            n.exp += (int)Random.Range((skillAdd[i].exp * .8f), (skillAdd[i].exp * 1.2f));
            LevelingUp(n);
        }
    }

    public void LevelingUp(Skills n)
    {
        if(n.level == 10)
        {
            return;
        }
        switch (n.expSpeed)
        {
            case Skills.ExpSpeed.Quick:
                #region QuickEXP
                if (n.level == 0 && n.exp >= 80)
                {
                    n.level = 1;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                } 
                else if (n.level == 1 && n.exp >= 180)
                {
                    n.level = 2;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 2 && n.exp >= 300)
                {
                    n.level = 3;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 3 && n.exp >= 450)
                {
                    n.level = 4;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 4 && n.exp >= 650)
                {
                    n.level = 5;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 5 && n.exp >= 900)
                {
                    n.level = 6;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 6 && n.exp >= 1200)
                {
                    n.level = 7;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 7 && n.exp >= 1550)
                {
                    n.level = 8;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 8 && n.exp >= 1950)
                {
                    n.level = 9;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 9 && n.exp >= 2400)
                {
                    n.level = 10;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                break;
            #endregion
            case Skills.ExpSpeed.Normal:
                #region NormalEXP
                if (n.level == 0 && n.exp >= 120)
                {
                    n.level = 1;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 1 && n.exp >= 270)
                {
                    n.level = 2;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 2 && n.exp >= 470)
                {
                    n.level = 3;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 3 && n.exp >= 770)
                {
                    n.level = 4;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 4 && n.exp >= 1100)
                {
                    n.level = 5;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 5 && n.exp >= 1600)
                {
                    n.level = 6;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 6 && n.exp >= 2100)
                {
                    n.level = 7;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 7 && n.exp >= 2800)
                {
                    n.level = 8;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 8 && n.exp >= 3600)
                {
                    n.level = 9;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 9 && n.exp >= 4500)
                {
                    n.level = 10;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                break;
            #endregion
            case Skills.ExpSpeed.Slow:
                #region SlowEXP
                if (n.level == 0 && n.exp >= 150)
                {
                    n.level = 1;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 1 && n.exp >= 300)
                {
                    n.level = 2;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 2 && n.exp >= 600)
                {
                    n.level = 3;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 3 && n.exp >= 1050)
                {
                    n.level = 4;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 4 && n.exp >= 1650)
                {
                    n.level = 5;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 5 && n.exp >= 2400)
                {
                    n.level = 6;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 6 && n.exp >= 3300)
                {
                    n.level = 7;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 7 && n.exp >= 4350)
                {
                    n.level = 8;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 8 && n.exp >= 5550)
                {
                    n.level = 9;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                else if (n.level == 9 && n.exp >= 6900)
                {
                    n.level = 10;
                    LevelSkills(n);
                    Debug.Log("Level up! Level " + n.level);
                    return;
                }
                break;
                #endregion

        }
    }
    /*
    public void LevelSkills(Skills n)
    {
        slimeSkills.GetComponent<SlimeSkills>().LevelUp();
        switch (n.id)
        {
            case 100:
                Debug.Log("Slime Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        break;
                    case 2:
                        //Whatever happens at level 2
                        break;
                    case 3:
                        //Whatever happens at level 3
                        break;
                    case 4:
                        //Whatever happens at level 4
                        break;
                    case 5:
                        //Whatever happens at level 5
                        break;
                    case 6:
                        //Whatever happens at level 6
                        break;
                    case 7:
                        //Whatever happens at level 7
                        break;
                    case 8:
                        //Whatever happens at level 8
                        break;
                    case 9:
                        //Whatever happens at level 9
                        break;
                    case 10:
                        //Whatever happens at level 10
                        break;
                }
                break;
            case 101:
                Debug.Log("Human Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        humanLevel = n.level;
                        break;
                    case 2:
                        //Whatever happens at level 2
                        humanLevel = n.level;
                        break;
                    case 3:
                        //Whatever happens at level 3
                        humanLevel = n.level;
                        break;
                    case 4:
                        //Whatever happens at level 4
                        humanLevel = n.level;
                        break;
                    case 5:
                        //Whatever happens at level 5
                        humanLevel = n.level;
                        break;
                    case 6:
                        //Whatever happens at level 6
                        humanLevel = n.level;
                        break;
                    case 7:
                        //Whatever happens at level 7
                        humanLevel = n.level;
                        break;
                    case 8:
                        //Whatever happens at level 8
                        humanLevel = n.level;
                        break;
                    case 9:
                        //Whatever happens at level 9
                        humanLevel = n.level;
                        break;
                    case 10:
                        //Whatever happens at level 10
                        humanLevel = n.level;
                        break;
                }
                break;
            case 102:
                Debug.Log("Skeleton Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        skeletonLevel = n.level;
                        break;
                    case 2:
                        //Whatever happens at level 2
                        skeletonLevel = n.level;
                        break;
                    case 3:
                        //Whatever happens at level 3
                        skeletonLevel = n.level;
                        break;
                    case 4:
                        //Whatever happens at level 4
                        skeletonLevel = n.level;
                        break;
                    case 5:
                        //Whatever happens at level 5
                        skeletonLevel = n.level;
                        break;
                    case 6:
                        //Whatever happens at level 6
                        skeletonLevel = n.level;
                        break;
                    case 7:
                        //Whatever happens at level 7
                        skeletonLevel = n.level;
                        break;
                    case 8:
                        //Whatever happens at level 8
                        skeletonLevel = n.level;
                        break;
                    case 9:
                        //Whatever happens at level 9
                        skeletonLevel = n.level;
                        break;
                    case 10:
                        //Whatever happens at level 10
                        skeletonLevel = n.level;
                        break;
                }
                break;
            case 200:
                Debug.Log("Blade Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        break;
                    case 2:
                        //Whatever happens at level 2
                        break;
                    case 3:
                        //Whatever happens at level 3
                        break;
                    case 4:
                        //Whatever happens at level 4
                        break;
                    case 5:
                        //Whatever happens at level 5
                        break;
                    case 6:
                        //Whatever happens at level 6
                        break;
                    case 7:
                        //Whatever happens at level 7
                        break;
                    case 8:
                        //Whatever happens at level 8
                        break;
                    case 9:
                        //Whatever happens at level 9
                        break;
                    case 10:
                        //Whatever happens at level 10
                        break;
                }
                break;
            case 201:
                Debug.Log("Bludgeon Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        break;
                    case 2:
                        //Whatever happens at level 2
                        break;
                    case 3:
                        //Whatever happens at level 3
                        break;
                    case 4:
                        //Whatever happens at level 4
                        break;
                    case 5:
                        //Whatever happens at level 5
                        break;
                    case 6:
                        //Whatever happens at level 6
                        break;
                    case 7:
                        //Whatever happens at level 7
                        break;
                    case 8:
                        //Whatever happens at level 8
                        break;
                    case 9:
                        //Whatever happens at level 9
                        break;
                    case 10:
                        //Whatever happens at level 10
                        break;
                }
                break;
            case 202:
                Debug.Log("Shoot Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        break;
                    case 2:
                        //Whatever happens at level 2
                        break;
                    case 3:
                        //Whatever happens at level 3
                        break;
                    case 4:
                        //Whatever happens at level 4
                        break;
                    case 5:
                        //Whatever happens at level 5
                        break;
                    case 6:
                        //Whatever happens at level 6
                        break;
                    case 7:
                        //Whatever happens at level 7
                        break;
                    case 8:
                        //Whatever happens at level 8
                        break;
                    case 9:
                        //Whatever happens at level 9
                        break;
                    case 10:
                        //Whatever happens at level 10
                        break;
                }
                break;
            case 300:
                Debug.Log("Armor Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        //Whatever happens at level 1
                        break;
                    case 2:
                        //Whatever happens at level 2
                        break;
                    case 3:
                        //Whatever happens at level 3
                        break;
                    case 4:
                        //Whatever happens at level 4
                        break;
                    case 5:
                        //Whatever happens at level 5
                        break;
                    case 6:
                        //Whatever happens at level 6
                        break;
                    case 7:
                        //Whatever happens at level 7
                        break;
                    case 8:
                        //Whatever happens at level 8
                        break;
                    case 9:
                        //Whatever happens at level 9
                        break;
                    case 10:
                        //Whatever happens at level 10
                        break;
                }
                break;
            case 400:
                Debug.Log("Storage Level" + n.level);
                switch (n.level)
                {
                    case 1:
                        GetComponent<Inventory>().space = 2;
                        //turn on i/b/inventory button
                        break;
                    case 2:
                        GetComponent<Inventory>().space = 4;
                        //turn on item slot 3/4
                        break;
                    case 3:
                        GetComponent<Inventory>().space = 6;
                        //turn on item slot 5/6
                        break;
                    case 4:
                        GetComponent<Inventory>().space = 8;
                        //turn on item slot 7/8
                        break;
                    case 5:
                        GetComponent<Inventory>().space = 10;
                        //turn on item slot 9/10
                        break;
                    case 6:
                        GetComponent<Inventory>().space = 12;
                        //turn on item slot 11/12
                        break;
                    case 7:
                        GetComponent<Inventory>().space = 14;
                        //turn on item slot 13/14
                        break;
                    case 8:
                        GetComponent<Inventory>().space = 16;
                        //turn on item slot 15/16
                        break;
                    case 9:
                        GetComponent<Inventory>().space = 18;
                        //turn on item slot 17/18
                        break;
                    case 10:
                        GetComponent<Inventory>().space = 20;
                        //turn on item slot 19/20
                        break;
                }
                break;

        }


    
    }
*/
}

