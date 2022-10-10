using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbilityBase;

public class TestAbility : AbilityBase
{
    // Start is called before the first frame update
    void Start()
    {
        Character = GetComponent<CharacterBase>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        if (Character.manaCurrent > manaCost)
        {
            Ray screenRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit, 75))
            {
                transform.position = hit.point;
                
            }
            Character.manaCurrent = Character.manaCurrent - manaCost; 
            print("activate new");
        }
    }

}
