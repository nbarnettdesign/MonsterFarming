using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ItemListCSV : MonoBehaviour
{

    public TextAsset itemListCSV;

    private char lineSeperater = '\n';
    private char fieldSeperator = ',';
    private string[] records;
    private string[] fields;



    void Start()
    {

        ReadData();
    }
    // Read data from CSV file
    private void ReadData()
    {
        records = itemListCSV.text.Split(lineSeperater);
        foreach (string record in records)
        {
            fields = record.Split(fieldSeperator);
            foreach (string field in fields)
            {
                //contentArea.text += field + "\t";
                FuckYaChickenStrips();
            }
            int num_rows = fields.Length;
            int num_cols = fields[0].Split(',').Length;
            Debug.Log("rows:" + num_rows + " columns:" + num_cols);
            //contentArea.text += '\n';
        }
    }

    public void FuckYaChickenStrips()
    {
        ScriptableObject.CreateInstance<Equipment>();
        //ScriptableObjectUtility.CreateAsset<ItemList>();
    }

}
