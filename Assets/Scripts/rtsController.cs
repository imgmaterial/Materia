using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class rtsController : MonoBehaviour

{
    public Camera playerCamera;
    NavMeshAgent agent;
    GameObject targetObject;
    public GameObject targetIndicatorPrefab;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        if (targetIndicatorPrefab)
        {
            targetObject = Instantiate(targetIndicatorPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            targetObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MoveToTarget(Input.mousePosition);
        }
        if (Vector3.Distance(targetObject.transform.position,transform.position)< 0.3)
        {
            animator.SetBool("isWalk", false);
        }
    }

    void MoveToTarget(Vector2 posOnScreen)
    {
        Ray screenRay = playerCamera.ScreenPointToRay(posOnScreen);

        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit, 75))
        {
            agent.destination = hit.point;
            animator.SetBool("isWalk", true);
            if (targetObject)
            {
                targetObject.transform.position = agent.destination;
                targetObject.SetActive(true);
            }
        }
    }
}
