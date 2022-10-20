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
            Instantiate(unit,new Vector3(gameObject.transform.position.x+UnityEngine.Random.Range(-5.0f,5.0f),0, gameObject.transform.position.z+ UnityEngine.Random.Range(-5.0f, 5.0f)),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    int WeightedGenerator(int UpperBound)
    {
        float unRandomVariable = UnityEngine.Random.value;
        if (unRandomVariable>0.5f)
        {
            return 0;
        }
        else
        {
            for (int i = 1; i < UpperBound; i++)
            {
                if (unRandomVariable>(0.4f*(1.0f/(i))))
                {
                    return i;
                }
            }
        }
        return 0;
    }
}
