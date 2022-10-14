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
    }

    // Update is called once per frame
    void Update()
    {
        if (state == stateDict["IDLE"])
        { 
            if (Vector3.Distance(destination, transform.position)<0.3)
            {
                destination = transform.position + new Vector3(Random.Range(-2.0f,2.0f), 0, Random.Range(-2.0f, 2.0f));
                agent.destination = destination;
                IEnumerator Chill()
                {
                     yield return new WaitForSeconds(Random.Range(2,7));
                }
                StartCoroutine(Chill());
            }
        }
    }

    public void Roam()
    {

    }
}
