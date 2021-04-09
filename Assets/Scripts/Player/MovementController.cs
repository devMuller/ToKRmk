using UnityEngine;

public class MovementController : MonoBehaviour
{
	public Rigidbody2D rb;

	public Animator anim;
	public SpriteRenderer sprite;

	Vector2 movement = Vector2.zero;
	static public bool canMove = false;
	public float speed = 5f;

	public bool debug;

	private void Update()
	{
		if (debug)
			canMove = debug;
		movement.y = Input.GetAxisRaw("Vertical");
		movement.x = Input.GetAxisRaw("Horizontal");
		
		if (movement != Vector2.zero && canMove)
		{
			if (movement.x != 0 && movement.y != 0)
				movement *= 0.75f;
			anim.SetBool("idle", false);
			if (movement.x > 0)
				sprite.flipX = false;
			else if (movement.x < 0)
				sprite.flipX = true;
		}
		else
		{
			anim.SetBool("idle", true);
		}
	}

	private void FixedUpdate()
	{
		if (movement != Vector2.zero && canMove)
			rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
	}
}
