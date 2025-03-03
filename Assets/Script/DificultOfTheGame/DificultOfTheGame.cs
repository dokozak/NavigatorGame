using Unity.AI.Navigation;
using UnityEngine;

public class DificultOfTheGame : MonoBehaviour
{
    public static int dificulty = 2;
    //If is easy, only have a map and a enemy
    public const int EASY = 0;
    //If is medium, only have a map but have two enemies
    public const int MEDIUM = 1;
    //If is Hard, have two maps and have 4 enemies to find you
    public const int HARD = 2;

    public GameObject[] toBeEnableMedium;
    public GameObject[] toBeEnableHard;
    public GameObject[] toBeDisableHard;

    public GameObject plataform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (dificulty) {
        case EASY:
                plataform.GetComponent<NavMeshSurface>().navMeshData = null;
                plataform.GetComponent<NavMeshSurface>().BuildNavMesh();
                GameGestions.winMoney = 7;
                break;
        case HARD:
                for (int i = 0; i < toBeEnableHard.Length; i++) toBeEnableHard[i].SetActive(true);
                for (int i = 0; i < toBeDisableHard.Length; i++) Destroy(toBeDisableHard[i]);
                for (int i = 0; i < toBeEnableMedium.Length; i++) toBeEnableMedium[i].SetActive(true);
                GameGestions.winMoney = 15;
                break;
        
        case MEDIUM:
                for (int i = 0; i < toBeEnableMedium.Length; i++) toBeEnableMedium[i].SetActive(true);
                plataform.GetComponent<NavMeshSurface>().navMeshData = null;
                plataform.GetComponent<NavMeshSurface>().BuildNavMesh();
                GameGestions.winMoney = 7;
                break;
        
        }
        Destroy(gameObject);
    }
}
