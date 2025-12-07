using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
}
