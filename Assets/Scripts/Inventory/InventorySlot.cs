using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public Item item;
    public ItemPickup itemPickup;
    public Crops cropPickup;
    InventoryManager inventoryManager;
    InventorySlot slot;

    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI stackNumber;
    public int textAmount;
    public int maxTextAmount;
    public bool isAvailable;
    GameObject hotbar;


    private void Start()
    {
        inventoryManager = (InventoryManager)FindObjectOfType(typeof(InventoryManager));
        slot = this;
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform grandchild in child)
            {
                //Debug.Log(child + " + " + child.tag);
                if (grandchild.CompareTag("Icon"))
                {
                    icon = grandchild.GetComponent<Image>();
                }
                else if (grandchild.CompareTag("Remove"))
                {
                    removeButton = grandchild.GetComponent<Button>();
                }
                else if (grandchild.CompareTag("StackNumber"))
                {
                    stackNumber = grandchild.GetComponent<TextMeshProUGUI>();
                }

            }
        }
            
    }

    public void AddItem (Item newItem, ItemPickup newItemPickup)
    {
        UpdateSlot();
        item = newItem;
        itemPickup = newItemPickup;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        stackNumber.text = item.stackNumber.ToString();
        textAmount = item.stackNumber;
        maxTextAmount = item.maxStackNumber;

        hotbar.GetComponent<HotbarSelect>().ActiveHotbar();
        if (stackNumber.text == "0")
        {
            stackNumber.text = "";
        }
        
    }

    public void AddCrop(Item newItem, Crops newItemPickup)
    {
        UpdateSlot();
        item = newItem;
        cropPickup = newItemPickup;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        stackNumber.text = item.stackNumber.ToString();
        textAmount = item.stackNumber;
        maxTextAmount = item.maxStackNumber;

        if (stackNumber.text == "0")
        {
            stackNumber.text = "";
        }

    }

    public void UpdateCropText()
    {
        //stackNumber.text = cropPickup.stackNumber.ToString();
        stackNumber.text = textAmount.ToString();
        if(textAmount == 0)
        {
            ClearSlot();
            inventoryManager.hotbar.GetComponent<HotbarSelect>().ActiveHotbar();
            return;
        }
        if (cropPickup.stackNumber >= cropPickup.maxStackNumber)
        {
            isAvailable = false;
            inventoryManager.availableSlots.Remove(this);
            inventoryManager.UpdateAvailableSlots();
        }
    }

    public void UpdateText()
    {
        stackNumber.text = itemPickup.stackNumber.ToString();
        if (itemPickup.stackNumber >= itemPickup.maxStackNumber)
        {
            isAvailable = false;
            inventoryManager.availableSlots.Remove(this);
            inventoryManager.UpdateAvailableSlots();
        }
    }


    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        stackNumber.text = "";


    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }



}
