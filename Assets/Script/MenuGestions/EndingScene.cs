using TMPro;
using UnityEngine;

public class EndingScene : MonoBehaviour
{

    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (GameGestions.money == GameGestions.winMoney){
            text.text = "You win";
        }
        else
        {
            text.text = "You lost";
        }
    }


}
