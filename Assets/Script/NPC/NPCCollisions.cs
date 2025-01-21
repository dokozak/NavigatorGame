using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene("FinishMenu");

        }
    }


}
