using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : Interactable
{
    public bool filled = false;
    public GameObject crop;
    GameObject grownFood;
    GameObject hotbar;

    private void Start()
    {
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");
    }
    public override void Interact()
    {
        base.Interact();

        Farm();

    }


    void Farm()
    {
        if (!filled)
        {

            crop= hotbar.GetComponent<HotbarSelect>().crop;
            InventorySlot activeSlot = hotbar.GetComponent<HotbarSelect>().activeHotbar.GetComponent<InventorySlot>();

            if(crop != null)
            {
                activeSlot.GetComponent<InventorySlot>().textAmount -= 1;
                activeSlot.GetComponent<InventorySlot>().UpdateCropText();
                grownFood = Instantiate(crop, this.transform) as GameObject;
                filled = true;
                float randNum = Random.Range(0f, 360f);
                grownFood.transform.rotation = Quaternion.Euler(0, randNum, 0);
                grownFood.GetComponent<Crops>().farmPlot = this.gameObject;
            }
            
            
        }
    }

}
