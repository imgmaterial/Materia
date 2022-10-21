using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AbilityBase : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterBase Character;
    public int manaCost = 30;
    public Camera playerCamera;
    void Start()
    {
        Character = GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {
        Character.manaCurrent = Character.manaCurrent - 30;
        print("Activated");
    }
}
