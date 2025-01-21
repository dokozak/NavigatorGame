using UnityEngine;

public class GameCoinsGestions : MonoBehaviour
{
    public GameObject coin;
    public GameObject [] points;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++) {
            Instantiate(coin, points[i].transform.position, Quaternion.identity);
        }
           Destroy(this);
        }
    }

