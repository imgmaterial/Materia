using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntellectUI : MonoBehaviour
{
    public GameObject mainCharacter;
    private CharacterBase character;
    private TextMeshProUGUI text;
    void Start()
    {
        character = mainCharacter.GetComponent<CharacterBase>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.SetText(character.strength.ToString());
        text.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("Intellect: " + character.intellect.ToString());

    }
}
