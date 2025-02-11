using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCPatronMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;

    private GameObject playerPosition;

    private EnumStatus status = EnumStatus.PATROL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childrenIndex = path.childCount;
        destination = path.GetChild(0).transform.position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(status);
        switch (status)
        {
            case EnumStatus.PATROL:
                PatrollMovement();
                break;
            case EnumStatus.ALERT:
                Alert();
                break;
            case EnumStatus.ATTACK:
                Attack();
                break;
        }

        
       
    }

    public void PatrollMovement()
    {
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            childrenIndex++;
            childrenIndex = childrenIndex % path.childCount;
            destination = path.GetChild(childrenIndex).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

    //The NPC are going to the player
    public void Alert()
    {
            destination = playerPosition.transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);

    }

    //The player lose
    public void Attack()
    {
        SceneManager.LoadScene("FinishMenu");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && status != EnumStatus.ALERT)
        {
            Debug.Log("player on range");
            playerPosition = other.gameObject;
            status = EnumStatus.ALERT;



        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(Vector3.Distance(transform.position, playerPosition.transform.position));
        if(Vector3.Distance(transform.position, playerPosition.transform.position) < 1f){
            status = EnumStatus.ATTACK;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && status != EnumStatus.PATROL)
        {
            status = EnumStatus.PATROL;
        }
    }
}
