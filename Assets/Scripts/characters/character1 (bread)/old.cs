using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    public float addForce;
    float speedX;
   
    bool isGrounded;

    SpriteRenderer m_SpriteRenderer;
    Rigidbody2D rb;
    Animator _animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, addForce), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
            m_SpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            m_SpriteRenderer.flipX = false;
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    //--------------------------------------------------------------

    void Timer()
    {
        float timeLeft = 60;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            
        }
    }
}