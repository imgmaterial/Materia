using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
    public GameObject mainCharacter;
    private CharacterBase character;
    private TextMeshProUGUI text;
    void Start()
    {
        character = mainCharacter.GetComponent<CharacterBase>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.SetText(character.strength.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("Mana: " + character.manaCurrent.ToString() + "/" + character.manaMax.ToString());


    }
}
