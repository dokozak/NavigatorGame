using UnityEngine;

public class GameCoinsGestions : MonoBehaviour
{
    public GameObject coin;
    public GameObject [] points;
    private GameObject coinNow;
    private int lastCoin;
    // Update is called once per frame
    void Update()
    {


        if (coinNow == null) {
            int randomPosition = lastCoin;
            while (lastCoin == randomPosition) {
               randomPosition = Random.Range(0, points.Length);

            }

            lastCoin = randomPosition;
            coinNow = Instantiate(coin, points[randomPosition].transform.position, Quaternion.identity);
        }
    }
}
