using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModifier : ModifierBase
{
    // Start is called before the first frame update
    void Start()
    {
        modifierDamage = 20.0f;
        modifierTickSpeed = 0.5f;
        modifierTime = 5.0f;
        ApplyDamageOverTime(modifierDamage,modifierTime,modifierTickSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
