using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicSlimeAi : MonoBehaviour
{
    private int state;
    private Animator animator;
    private NavMeshAgent agent;
    private Dictionary<string, int> stateDict = new Dictionary<string, int>() { { "IDLE", 1 }, { "CHASE", 2 }, { "RETURN", 3 }, { "ATTACK", 4 } };
    public Vector3 destination;
    private CharacterBase character;
    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterBase>();
        state = stateDict["IDLE"];
        destination = transform.position;
        InvokeRepeating("Roam", 2.0f, 5.0f);
        Attack(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<CharacterBase>());
        animator.fireEvents = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == stateDict["CHASE"])
        {
            if (Vector3.Distance(character.transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.position)>0.5)
            {
                Follow(GameObject.FindGameObjectsWithTag("Player")[0]);
            }
        }

    }
    
    public void Roam()
    {

        if (state == stateDict["IDLE"])
        {
            if (Vector3.Distance(destination, transform.position) < 0.3)
            {
                destination = transform.position + new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
                animator.SetBool("Jump", true);
                agent.destination = destination;
            }
        }
        if (Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.position)<10)
        {
            state = stateDict["CHASE"];
        }
    }

    public void Follow(GameObject target)
    {
        agent.destination = target.transform.position;
        animator.SetBool("Jump", true);
        if (Vector3.Distance(character.transform.position,target.transform.position)<1.0f)
        {
            state = stateDict["ATTACK"];
        }
        
    }

    public void Attack(CharacterBase target)
    {
        character.SetTarget(target);

        InvokeRepeating("AttackMotion", 0, 1.75f);
    }
    public void AttackMotion()
    {
        if (Vector3.Distance(character.transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.position) < 1.0f)
        {
            animator.SetBool("Attack", true);
        }
    }

}
