using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCRandomMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Vector3 min, max;

    [SerializeField] private GameObject player;

    private EnumStatus status = EnumStatus.PATROL;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destination = RandomDestination();
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

    void PatrollMovement()
    {
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
            transform.LookAt(destination);
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




    #region Random Destination
    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }

    #endregion


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
