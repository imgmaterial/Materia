using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbilityBase;

public class AbilityManager : MonoBehaviour
{
    public List<AbilityBase> abilities = new List<AbilityBase>();
    public Dictionary<string, AbilityBase> abilitiesDictionary = new Dictionary<string, AbilityBase>(); 
    
    void Start()
    {
        int i = 0;
        foreach (AbilityBase ability in abilities)
        {
            if (ability != null)
            {
                abilitiesDictionary.Add("ability" + i, ability);
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (abilitiesDictionary["ability0"] != null)
            {
                abilitiesDictionary["ability0"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (abilitiesDictionary["ability1"] != null)
            {
                abilitiesDictionary["ability1"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abilitiesDictionary["ability2"] != null)
            {
                abilitiesDictionary["ability2"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (abilitiesDictionary["ability3"] != null)
            {
                abilitiesDictionary["ability3"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (abilitiesDictionary["ability4"] != null)
            {
                abilitiesDictionary["ability4"].Activate();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (abilitiesDictionary["ability5"] != null)
            {
                abilitiesDictionary["ability5"].Activate();
            }
        }
    }
}
