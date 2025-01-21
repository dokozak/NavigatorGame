using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGestions : MonoBehaviour
{
    public static int money = 0;
    public static int winMoney = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (money == winMoney)
        {
            SceneManager.LoadScene("FinishMenu");
        }
    }
}
