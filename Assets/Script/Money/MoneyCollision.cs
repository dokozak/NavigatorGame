using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    private bool isDelete = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isDelete) 
            GameGestions.money++;
            isDelete = true;
            Destroy(gameObject);
        }

    }
}
