using TMPro;
using UnityEngine;

public class CanvasMoneyInfo : MonoBehaviour
{
    public TextMeshProUGUI text;


    // Update is called once per frame
    void Update()
    {
        text.text = "You have " + GameGestions.money +"/" + GameGestions.winMoney + " coins";        
    }
}
