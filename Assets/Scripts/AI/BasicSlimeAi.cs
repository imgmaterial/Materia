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
    private Dictionary<string, int> stateDict = new Dictionary<string, int>() { { "IDLE", 1 }, { "CHASE", 2 }, { "RETURN", 3 } };
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        state = stateDict["IDLE"];
        destination = transform.position;
        InvokeRepeating("Roam", 2.0f, 5.0f);
        animator.fireEvents = false;
    }

    // Update is called once per frame
    void Update()
    {

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
    }

}
