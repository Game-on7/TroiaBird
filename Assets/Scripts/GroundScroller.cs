using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = .5f;
    private Material mat;
    private Vector2 offset;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            offset.x += scrollSpeed * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
    }
}
