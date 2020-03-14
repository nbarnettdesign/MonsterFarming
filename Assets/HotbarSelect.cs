using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarSelect : MonoBehaviour
{
    public GameObject activeHotbar;
    public string searchTag;
    public string highlightTag;
    public GameObject crop;
    public List<GameObject> inventorySlots = new List<GameObject>();
    public List<GameObject> inventoryHighlight = new List<GameObject>();

    void Start()
    {
        if (searchTag != null)
        {
            FindObjectwithTag(searchTag);
        }
        if (highlightTag != null)
        {
            FindHighlightwithTag(highlightTag);
        }
        activeHotbar = inventorySlots[0];
        ActiveHotbar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeHotbar = inventorySlots[0];
            ActiveHotbar();
        }
         else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeHotbar = inventorySlots[1];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeHotbar = inventorySlots[2];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeHotbar = inventorySlots[3];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activeHotbar = inventorySlots[4];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            activeHotbar = inventorySlots[5];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            activeHotbar = inventorySlots[6];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            activeHotbar = inventorySlots[7];
            ActiveHotbar();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            activeHotbar = inventorySlots[8];
            ActiveHotbar();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            activeHotbar = inventorySlots[9];
            ActiveHotbar();
        }
    }

    public void ActiveHotbar()
    {
       
        for (int i = 0; i < inventoryHighlight.Count; i++)
        {
            if (inventorySlots[i] == activeHotbar)
            {
                inventoryHighlight[i].SetActive(true);
            }
            else inventoryHighlight[i].SetActive(false);
        }
        if (activeHotbar.GetComponent<InventorySlot>().item != null)
        {
            crop = activeHotbar.GetComponent<InventorySlot>().item.prefab;
        }
        else crop = null;

    }

    #region MakeTheLists
    public void FindObjectwithTag(string _tag)
    {
        inventorySlots.Clear();
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }
    public void FindHighlightwithTag(string _tag)
    {
        inventoryHighlight.Clear();
        Transform parent = transform;
        GetChildHighlight(parent, _tag);
    }


    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                inventorySlots.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag);
            }
        }
    }
    public void GetChildHighlight(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                inventoryHighlight.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildHighlight(child, _tag);
            }
        }
    }
    #endregion
}
