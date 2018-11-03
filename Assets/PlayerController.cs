using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 2f;
    public float jumpForce = 500f;

    public Transform probe;
    public LayerMask groundMask;

    Animator animator;
    Rigidbody2D body;
    SpriteRenderer sprite;
    bool grounded = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
    {
	}

    private void FixedUpdate()
    {
        float speed = Input.GetAxis("Horizontal") * maxSpeed;
        body.velocity = new Vector2(speed, body.velocity.y);

        grounded = Physics2D.OverlapCircle(probe.position, 0.1f, groundMask);

        if (grounded && Input.GetButton("Jump"))
        {
            grounded = false;
            body.AddForce(new Vector2(0f, jumpForce));
        }

        bool flip = sprite.flipX ? (speed > 0) : (speed < 0);
        if (flip)
        {
            sprite.flipX = !sprite.flipX;
        }

        animator.SetFloat("speed", Mathf.Abs(speed));
        animator.SetFloat("vspeed", Mathf.Abs(body.velocity.y));
    }
}
