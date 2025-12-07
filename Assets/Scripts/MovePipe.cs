using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
    }
}
