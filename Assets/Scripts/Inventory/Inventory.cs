using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public bool absorbing;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();
    public List<int> itemCount = new List<int>();
   // public List<TextMeshProUGUI> inventorySlotText= new List<TextMeshProUGUI>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("not enough room.");
                Debug.Log("Returning false 40");
                return false;
            }
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].name == item.name)
                {
                    itemCount[i] += 1;
                    Debug.Log(item.name + ": " + itemCount[i]);
                    //inventorySlotText[i].text = itemCount[i].ToString();
                    Debug.Log("Returning True 49");
                    return true;
                }
            }
            items.Add(item);
            itemCount.Add(1);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        Debug.Log("Returning True 59");
        return true;

    }

    public bool Eat(Item item)
    {
        if (absorbing)
        {
            return true;

        }
        return false;

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
