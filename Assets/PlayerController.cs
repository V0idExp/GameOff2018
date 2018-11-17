using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 2f;

    Rigidbody2D body;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
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

        bool flip = sprite.flipX ? (speed > 0) : (speed < 0);
        if (flip)
        {
            sprite.flipX = !sprite.flipX;
        }
    }
}
