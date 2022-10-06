using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public float healthMax = 100;
    public float heathCurrent;
    public int manaMax = 100;
    public int manaCurrent = 100;
    public int strength = 20;
    public int agility = 20;
    public int intellect = 20;
    public int damage = 20;
    public int armor = 10;
    private float damageRecived;
    void Start()
    {
        healthMax = healthMax + strength * 25;  
        heathCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float _damage, CharacterBase source)
    {
        heathCurrent = heathCurrent - _damage;
    }

    public void ApplyDamage(int _damage, CharacterBase target)
    {
        damageRecived = _damage * 1/target.armor;
        target.TakeDamage(damageRecived, this);
    }

    public void heal(int _heal, CharacterBase source)
    {
        heathCurrent = heathCurrent + _heal;
    }
}
