using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterBase : MonoBehaviour
{
    public float healthMax = 100;
    public float experiance;
    public int level = 1; 
    public float heathCurrent;
    public float manaMax = 100;
    public float manaCurrent = 100;
    public int strength = 20;
    public int agility = 20;
    public int intellect = 20;
    public int damage = 20;
    public int expReturn = 20;
    public float armor = 10;
    public float attackSpeed = 0.5f;
    public float attackRange = 3;
    private int expToLevel = 100;
    private float damageRecived;
    private CharacterBase currentTarget;
    void Start()
    {
        CalculateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (heathCurrent < 0)
        {
            Destroy(gameObject);
            ExpOnDeath();
        }

        if (experiance > expToLevel)
        {
            experiance = 0;
            level++;
        }
    }

    public void TakeDamage(float _damage, CharacterBase source)
    {
        damageRecived = _damage - (_damage * 1 / armor);
        heathCurrent = heathCurrent - _damage;
    }

    public void ApplyDamage(int _damage, CharacterBase target)
    {
        target.TakeDamage(_damage, this);
    }

    public void heal(int _heal, CharacterBase source)
    {
        heathCurrent = heathCurrent + _heal;
    }

    public void SetTarget(CharacterBase _target)
    {
        currentTarget = _target;
        if (currentTarget != null)
        {
            AutoAttack(_target);
        }
    }

    private void AutoAttack(CharacterBase _target)
    {
        IEnumerator WaitForAttack()
        {
            while (currentTarget != null)
            {
                yield return new WaitForSeconds(attackSpeed);
                Attack(_target);
            }
        }
        StartCoroutine(WaitForAttack());
    }

    private void Attack(CharacterBase _target)
    {
        CharacterBase attackTarget = _target;
        if (attackTarget != null & Vector3.Distance(transform.position, attackTarget.transform.position) < attackRange)
        {
            ApplyDamage(damage, attackTarget);
        }

    }

    private float CalculateHealth()
    {
        float healthPerStr = 25;

        return healthMax + strength*healthPerStr;
    }

    private float CalculateMana()
    {
        float manaPerInt = 25;
        return manaMax + intellect * manaPerInt;
    }

    private float CalculateArmor()
    {
        float armorPerAgi = 1;
        return armor + agility * armorPerAgi;
    }

    private void CalculateStats()
    {
        healthMax = CalculateHealth();
        heathCurrent = healthMax;
        manaMax = CalculateMana();
        manaCurrent = manaMax;
        armor = CalculateArmor();
    }

    public void ExpOnDeath()
    {
        CharacterBase player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<CharacterBase>();
        player.experiance = player.experiance + expReturn;
        
    }
}
