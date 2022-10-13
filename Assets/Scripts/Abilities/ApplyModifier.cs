using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ApplyModifier : AbilityBase
{
    public Animator animator;
    void Start()
    {
        Character = GetComponent<CharacterBase>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddModifier()
    {
        Ray screenRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit))
        {

            if (hit.collider != null && hit.collider.gameObject.GetComponent<CharacterBase>() != null)
            {
                ModifierBase testmodifier = hit.collider.gameObject.AddComponent<TestModifier>();
                testmodifier.caster = Character;
                testmodifier.character = hit.collider.gameObject.GetComponent<CharacterBase>();
                Character.manaCurrent = Character.manaCurrent - manaCost;
            }
        }
        animator.SetBool("attack", true);
    }

    public override void Activate()
    {
        AddModifier();
    }
}
