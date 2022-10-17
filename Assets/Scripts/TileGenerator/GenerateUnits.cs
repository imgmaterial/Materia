using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateUnits : MonoBehaviour
{   
    public GameObject unit;
    public int tileLevel;
    // Start is called before the first frame update
    void Start()
    {
        int randomValue = WeightedGenerator(10);
        tileLevel = randomValue;
        for (int i = 0; i < tileLevel; i++)
        {
            Instantiate(unit,new Vector3(gameObject.transform.position.x,0, gameObject.transform.position.z),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int WeightedGenerator(int UpperBound)
    {
        float unRandomVariable = UnityEngine.Random.value;
        print(unRandomVariable);
        if (unRandomVariable>0.6f)
        {
            return 0;
        }
        else
        {
            for (int i = 1; i < UpperBound; i++)
            {
                if (unRandomVariable>0.5*(1/(i)))
                {
                    
                    return i;
                }
            }
        }
        return 0;
    }
}
