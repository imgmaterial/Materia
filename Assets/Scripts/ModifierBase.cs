using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ModifierBase : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterBase caster;
    public CharacterBase character;
    public float modifierDamage;
    public float modifierTime;
    public float modifierTickSpeed;
    void Start()
    {
        character = GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ApplyDamage(float damage)
    {
        character.TakeDamage(damage,caster);
    }
    public void ApplyDamageOverTime(float _damage, float _duration, float _tickRate)
    {
        IEnumerator WaitForDamage()
        {
            int i = 0;
            while (i*_tickRate<_duration)
            {
                yield return new WaitForSeconds(_tickRate);
                ApplyDamage(_damage);
                i++;
            }
            Destroy(this);
        }
        StartCoroutine(WaitForDamage());
    }
}
