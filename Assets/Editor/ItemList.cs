using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ItemList")]
public class ItemList : ScriptableObject {


    public int id;
    new public string name = "New Item";
    public string skill1 = "Skill 1";
    public int exp1;
    public string skill2 = "Skill 2";
    public int exp2;
    public string skill3 = "Skill 3";
    public int exp3;




    public virtual void Use()
    {
        //use the item
        //something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        //Inventory.instance.Remove(this);
    }

}