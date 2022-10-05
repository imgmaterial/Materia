using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public static int healthMax = 100;
    public int heathCurrent = 100;
    public int manaMax = 100;
    public int manaCurrent = 100;
    public int strength = 20;
    public int agility = 20;
    public int intellect = 20;
    public int damage = 20;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int _damage, CharacterBase source)
    {
        heathCurrent = heathCurrent-_damage;
    }

    public void ApplyDamage(int _damage, CharacterBase target)
    {
        target.TakeDamage(_damage, this);
    }

    public void heal(int _heal, CharacterBase source)
    {
        heathCurrent = heathCurrent + _heal;
    }
}
