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
            abilitiesDictionary["ability0"].Activate();
        }
    }
}
