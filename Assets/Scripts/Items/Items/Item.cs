using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public int stackNumber;
    public int maxStackNumber;
    public bool isStackable;
    public bool isDefaultItem = false;
    public int ID;
    public GameObject prefab;
    public bool multipleLoot;
    public int lowerLootAmount;
    public int upperLootAmount;

    public List<Skills> skills = new List<Skills>();

    public virtual void Use()
    {
        //use the item
        //something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
[System.Serializable]
public class Skills
{
    public uint id;
    public string skill;
    public float exp;
    public int level;
    public enum ExpSpeed { Quick, Normal, Slow };
    public ExpSpeed expSpeed;
}
