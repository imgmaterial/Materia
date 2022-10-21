using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
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
        text.SetText("Health: " + character.heathCurrent.ToString() + "/" + character.healthMax.ToString());
        if (character.heathCurrent / character.healthMax > 0.5f)
        {
            text.color = Color.green;
        }
        else if (character.heathCurrent / character.healthMax < 0.5f)
        {
            text.color = Color.red;
        }

    }
}
