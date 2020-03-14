using UnityEngine;
using UnityEditor;

public class ItemListAsset
{
    [MenuItem("Assets/Create/ItemList")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<ItemList>();
    }
}
