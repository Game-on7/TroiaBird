using UnityEngine;

public class EdgeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "score")
        {
            Destroy(collision.gameObject);
        }
    }
}
