using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crops : Interactable
{
    public float timeToGrow;
    float growthTimer;
    bool finishedGrowing;
    public GameObject farmPlot;

    public Item item;
    public GameObject cropMesh;
    public Slider slider;
    public Crops itemPickup;
    public InventoryManager inventoryManger;
    public bool wasPickedUp;
    public bool notPickupable;
    public int stackNumber;
    public bool isStackable;
    public int maxStackNumber;

    public override void Interact()
    {
        base.Interact();

        Harvest();

    }

    private void Start()
    {
        itemPickup = this;
        growthTimer = 0;
        slider.value = 0;
        inventoryManger = FindObjectOfType<InventoryManager>();
    }

    private void LateUpdate()
    {
        if (!finishedGrowing)
        {
            if (growthTimer <= timeToGrow)
            {
                growthTimer += Time.deltaTime;
                cropMesh.transform.localScale = new Vector3((growthTimer / timeToGrow), (growthTimer / timeToGrow), (growthTimer / timeToGrow));
                slider.value = growthTimer / timeToGrow;
            }
            else
            {
                finishedGrowing = true;
                slider.value = 1;
                slider.gameObject.SetActive(false);
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                if (item.multipleLoot)
                {
                    item.stackNumber = Random.Range(item.lowerLootAmount, item.upperLootAmount + 1);
                    stackNumber = item.stackNumber;
                }
            }
        }

    }

    void PickUp()
    {
 
        if (!notPickupable)
        {
            wasPickedUp = inventoryManger.CropIncoming(itemPickup);
        }

        if (wasPickedUp)
        {
            Debug.Log("ITEMPICKUP: Picking up " + item.name);
            Destroy(gameObject);
        }


    }

    void Harvest()
    {
        if (finishedGrowing)
        {
            if (farmPlot != null)
            {
                farmPlot.GetComponent<FarmPlot>().filled = false;
            }

            //Add Corn to inventory
            //Destroy(this.gameObject);
            PickUp();
        }
    }
}
