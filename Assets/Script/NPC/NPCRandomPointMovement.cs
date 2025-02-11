using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCRandomPointMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;

    [SerializeField] private GameObject player;

    private EnumStatus status = EnumStatus.PATROL;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childrenIndex = path.childCount;
        randomDestination();
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
            randomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

    public void Alert()
    {
        destination = player.transform.position;
        GetComponent<NavMeshAgent>().SetDestination(destination);

    }

    public void Attack()
    {
        SceneManager.LoadScene("FinishMenu");
    }

    private void randomDestination()
    {
        destination = path.GetChild(Random.Range(0, childrenIndex)).position;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && status != EnumStatus.ALERT)
        {
            Debug.Log("player on range");
            player = other.gameObject;
            status = EnumStatus.ALERT;



        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
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
