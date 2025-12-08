using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f, rotationPow = 10f;

    public Rigidbody2D rb;
    UIManager uIManager;
    public bool firstTap = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        uIManager = Object.FindFirstObjectByType<UIManager>();
    }
    private void Start()
    {
        rb.simulated = false;
    }
    private void Update()
    {
        // 1. Mouse Týklamasý Var mý? (Mouse takýlýysa ve sol týklandýysa)
        bool isMouseClicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        // 2. Ekrana Dokunuldu mu? (Dokunmatik ekran varsa ve basýldýysa)
        bool isTouched = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if ((isMouseClicked || isTouched)&& GameManager.instance.gameStarted)
        {
            if (!firstTap)
            {
                firstTap = true;
                rb.simulated = true;
            }


            rb.linearVelocity = Vector2.up * jumpForce;
            SFXManager.instance.Play("swoosh");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "score")
        {
            uIManager.UpdateScore(++GameManager.instance.score);
            SFXManager.instance.Play("score");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pipe")
        {
            uIManager.ShowGameOverUI();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameStarted)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * rotationPow);
        }
    }
}
