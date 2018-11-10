using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 2f;
    public float jumpForce = 500f;
    public bool jumpEnabled = false;

    public Transform probe;
    public LayerMask groundMask;

    public AudioClip jumpSound;

    Animator animator;
    Rigidbody2D body;
    SpriteRenderer sprite;
    new AudioSource audio;

    bool grounded = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
	}

    private void FixedUpdate()
    {
        float speed = Input.GetAxis("Horizontal") * maxSpeed;
        body.velocity = new Vector2(speed, body.velocity.y);

        if (jumpEnabled)
        {
            grounded = Physics2D.OverlapCircle(probe.position, 0.1f, groundMask);
            if (grounded && Input.GetButton("Jump"))
            {
                Jump();
            }
        }

        bool flip = sprite.flipX ? (speed > 0) : (speed < 0);
        if (flip)
        {
            sprite.flipX = !sprite.flipX;
        }

        animator.SetFloat("speed", Mathf.Abs(speed));
        animator.SetFloat("vspeed", Mathf.Abs(body.velocity.y));
    }

    private void Jump()
    {
        grounded = false;
        body.AddForce(new Vector2(0f, jumpForce));
        audio.PlayOneShot(jumpSound);
    }
}
