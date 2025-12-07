using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f, rotationPow = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 1. Mouse Týklamasý Var mý? (Mouse takýlýysa ve sol týklandýysa)
        bool isMouseClicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        // 2. Ekrana Dokunuldu mu? (Dokunmatik ekran varsa ve basýldýysa)
        bool isTouched = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if (isMouseClicked || isTouched)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * rotationPow);
    }
}
