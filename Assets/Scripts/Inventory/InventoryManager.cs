using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    #region Singleton

    public static InventoryManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
        }
        instance = this;
    }

    #endregion

    InventorySlot[] slots;
    InventorySlot[] hotkeySlots;
    public Transform itemsParent;
    public Transform hotkeyParent;
    public List<InventorySlot> availableSlots;
    public GameObject hotbar;

    private void Start()
    {
        CheckSlots();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("CHANGE PLACES!");
            CheckSlots();
        }
    }

    public void CheckSlots()
    {
        availableSlots = new List<InventorySlot>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        hotkeySlots = hotkeyParent.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < hotkeySlots.Length; i++)
        {
            if (hotkeySlots[i].isAvailable == true)
            {
                availableSlots.Add(hotkeySlots[i]);
            }

        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isAvailable == true)
            {
                availableSlots.Add(slots[i]);
            }

        }
    }

    //Set how many are locked/available
    //have list of how many slots are free/in use
    //Saves name of each slot item to check if stackable
    public void UpdateAvailableSlots()
    {
        availableSlots = new List<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isAvailable == true)
            {
                availableSlots.Add(slots[i]);
            }
            i++;
        }
        //Debug.Log("INVENTORYMANAGER: Available Slots Updated");
    }

    public bool CropIncoming(Crops itemBeingPickedUp)
    {
        //false should probably display in world somehow
        //Debug.Log("INVENTORYMANAGER/itemInc: ITEM BEING PICKED UP");
        //check if item is stackable
        if (itemBeingPickedUp.isStackable == true)
        {
            //Debug.Log("INVENTORYMANAGER/itemInc: Item Pickup is Stackable");
            //for every available slot (slot that is unlocked and not maxed out)
            for (int i = 0; i < availableSlots.Count; i++)
            {
                //Debug.Log("INVENTORYMANAGER/itemInc: Checking Slot " + i);
                //if the item in the slot has the same name


                if (availableSlots[i].item == itemBeingPickedUp.item && availableSlots[i].maxTextAmount != availableSlots[i].textAmount)
                {
                    return CropThoseSuckers(itemBeingPickedUp, i);
                }
            }
        }
        //Debug.Log("INVENTORYMANAGER/itemInc: Checking for Empty Slot");
        return CropForEmptySlot(itemBeingPickedUp);
    }


    public bool ItemIncoming(ItemPickup itemBeingPickedUp)
    {
        //false should probably display in world somehow
        //Debug.Log("INVENTORYMANAGER/itemInc: ITEM BEING PICKED UP");
        //check if item is stackable
        if (itemBeingPickedUp.isStackable == true)
        {
            //Debug.Log("INVENTORYMANAGER/itemInc: Item Pickup is Stackable");
            //for every available slot (slot that is unlocked and not maxed out)
            for (int i = 0; i < availableSlots.Count; i++)
            {
                //Debug.Log("INVENTORYMANAGER/itemInc: Checking Slot " + i);
                //if the item in the slot has the same name


                if (availableSlots[i].item == itemBeingPickedUp.item && availableSlots[i].maxTextAmount != availableSlots[i].textAmount )
                {
                    return StackThoseSuckers(itemBeingPickedUp, i);
                }
            }
        }
        //Debug.Log("INVENTORYMANAGER/itemInc: Checking for Empty Slot");
        return CheckForEmptySlot(itemBeingPickedUp);
    }

    bool CropForEmptySlot(Crops itemBeingPickedUp)
    {
        for (int i = 0; i < availableSlots.Count; i++)
        {
            //Debug.Log("INVENTORYMANAGER/checkSlots: Slot item = " + availableSlots[i].item);
            //might need to change name beslow into item, check if item works, would prefer that
            if (availableSlots[i].item == null)
            {
                availableSlots[i].AddCrop(itemBeingPickedUp.item, itemBeingPickedUp);
                availableSlots[i].UpdateCropText();
                hotbar.GetComponent<HotbarSelect>().ActiveHotbar();
                //Debug.Log("INVENTORYMANAGER/checkSlots: Slot item = " + availableSlots[i].item);
                return true;
            }
        }
        return false;
    }

    bool CheckForEmptySlot(ItemPickup itemBeingPickedUp)
    {
        for (int i = 0; i < availableSlots.Count; i++)
        {
            //Debug.Log("INVENTORYMANAGER/checkSlots: Slot item = " + availableSlots[i].item);
            //might need to change name beslow into item, check if item works, would prefer that
            if (availableSlots[i].item == null)
            {
                availableSlots[i].AddItem(itemBeingPickedUp.item, itemBeingPickedUp);
                availableSlots[i].UpdateText();
                //Debug.Log("INVENTORYMANAGER/checkSlots: Slot item = " + availableSlots[i].item);
                return true;
            }
        }
        return false;
    }


    public bool CropThoseSuckers(Crops itemBeingPickedUp, int i)
    {
        //if max stack number on item is less than however many is in there plus the amount coming in

        if (availableSlots[i].item.maxStackNumber <= availableSlots[i].textAmount + itemBeingPickedUp.stackNumber)
        {
            itemBeingPickedUp.stackNumber -= (availableSlots[i].item.maxStackNumber - availableSlots[i].textAmount);
            availableSlots[i].textAmount = availableSlots[i].item.maxStackNumber;
            availableSlots[i].UpdateCropText();
            if (itemBeingPickedUp.stackNumber == 0)
            {
                //if its 0 it destroys it, if not then the number is changed and it continues to exist
                return true;
            }
            else if (itemBeingPickedUp.stackNumber != 0)
            {
                //check for free spot for the rest?
                return CropForEmptySlot(itemBeingPickedUp);
            }
        }
        else if (availableSlots[i].item.maxStackNumber > availableSlots[i].textAmount + itemBeingPickedUp.stackNumber)
        {
            availableSlots[i].textAmount += itemBeingPickedUp.stackNumber;
            availableSlots[i].UpdateCropText();

            return true;
        }
        return false;
    }

    public bool StackThoseSuckers(ItemPickup itemBeingPickedUp, int i)
    {
        //if max stack number on item is less than however many is in there plus the amount coming in
        if (availableSlots[i].item.maxStackNumber <= availableSlots[i].textAmount + itemBeingPickedUp.stackNumber)
        {
            itemBeingPickedUp.stackNumber -= (availableSlots[i].item.maxStackNumber - availableSlots[i].textAmount);
            availableSlots[i].textAmount = availableSlots[i].item.maxStackNumber;
            availableSlots[i].UpdateText();
            if (itemBeingPickedUp.stackNumber == 0)
            {
                //if its 0 it destroys it, if not then the number is changed and it continues to exist
                return true;
            }
            else if(itemBeingPickedUp.stackNumber != 0)
            {
                //check for free spot for the rest?
                return CheckForEmptySlot(itemBeingPickedUp);
            }
        }
        else if(availableSlots[i].item.maxStackNumber > availableSlots[i].textAmount + itemBeingPickedUp.stackNumber)
        {
            availableSlots[i].textAmount += itemBeingPickedUp.stackNumber;
            availableSlots[i].UpdateText();

            return true;
        }
        return false;
    }

    void DropItem()
    {
        //Remove from slot
        //spawn item in world at player (Steal random drop position code from chest)
        //give item that spawns the same stack
    }

   






    //for ITEM SLOT SCRIPT
    //needs Icon, Drop button, Stack Number, UI FOR ALL
    //Item its holding ****
    //if available or not
    //not available if locked or if reached stack max amount.

    //For ITEMS SPECIFICALLY
    // is stackable bool
    //max stack size otherwise.
    //maybe add a grab items in area when dropped that are same as it and add it to pile
    //Item slots to see if it can be added to a stack
    //if no, check if free slot

    //if yes search current used slots for name, if no, check if any slots free, if no, no pickup
    //if yes, assign to slot
}