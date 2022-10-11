using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<ItemBase> items = new List<ItemBase>();
    public Dictionary<string, ItemBase> itemsDict = new Dictionary<string, ItemBase>();
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (ItemBase item in items)
        {
            if (i == 0)
            {
                itemsDict.Add("item" + i, item);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (itemsDict["item0"] != null)
            {
                itemsDict["item0"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (itemsDict["item1"] != null)
            {
                itemsDict["item1"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (itemsDict["item2"] != null)
            {
                itemsDict["item2"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (itemsDict["item3"] != null)
            {
                itemsDict["item3"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (itemsDict["item4"] != null)
            {
                itemsDict["item4"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (itemsDict["item5"] != null)
            {
                itemsDict["item5"].Activate();
            }
        }
    }
}
