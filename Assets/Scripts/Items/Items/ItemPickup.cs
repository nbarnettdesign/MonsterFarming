
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public ItemPickup itemPickup;
    public InventoryManager inventoryManger;
    public bool wasEaten;
    public bool wasPickedUp;
    public bool notPickupable;
    public int stackNumber;
    public bool isStackable;
    public int maxStackNumber;

    private void Start()
    {
        maxStackNumber = item.maxStackNumber;
        isStackable = item.isStackable;
        inventoryManger = FindObjectOfType<InventoryManager>();
        itemPickup = this;
    }


    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {

        //wasEaten = Inventory.instance.Eat(item);
        wasEaten = false;
        if (!wasEaten && !notPickupable)
        {
            //wasPickedUp = Inventory.instance.Add(item);
            wasPickedUp = inventoryManger.ItemIncoming(itemPickup);
        }

        if (wasPickedUp)
        {
            Debug.Log("ITEMPICKUP: Picking up " + item.name);
            Destroy(gameObject);
        }
        if (wasEaten)
        {
            Debug.Log("ITEMPICKUP: Eating " + item.name);
            //PlayerExp.instance.Absorb(this);
            Destroy(gameObject);
        }


    }

}
