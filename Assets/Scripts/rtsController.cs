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
    private CharacterBase character;
    void Start()
    {
        character = GetComponent<CharacterBase>();
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
            SelectTarget(Input.mousePosition);
        }
        if (Vector3.Distance(targetObject.transform.position,transform.position)< 0.3)
        {
            animator.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectTarget(Input.mousePosition);
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

    void SelectTarget(Vector2 posOnScreen)
    {
        Ray screenRay = playerCamera.ScreenPointToRay(posOnScreen);
        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit))
        {
            
            if (hit.collider != null && hit.collider.gameObject.GetComponent<CharacterBase>()!= null)
            {        
                character.SetTarget(hit.collider.gameObject.GetComponent<CharacterBase>());
            }
            else
            {
                character.SetTarget(null);
            }
        }
    }
}
