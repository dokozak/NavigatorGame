using UnityEngine;

public class DisableGameObjects : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
