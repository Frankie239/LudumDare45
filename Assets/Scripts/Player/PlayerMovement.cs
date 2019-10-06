using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 2f;

	private Animator animator;
	private Rigidbody2D rb;
	float horizontal;
	float vertical;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

		if (horizontal != 0)
		{
			if (horizontal > 0)
			{
				animator.Play("MoveRight");
			}
			if (horizontal < 0)
			{
				animator.Play("MoveLeft");
			}
		}
		else if (vertical != 0)
		{
			if (vertical > 0)
			{
				animator.Play("MoveUp");
			}
			if (vertical < 0)
			{
				animator.Play("MoveDown");
			}
		}



		if (Input.GetKey(KeyCode.R))
		{
			Restart();
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition(
			new Vector2(transform.position.x, transform.position.y) +
			new Vector2(horizontal, vertical) * movementSpeed * Time.fixedDeltaTime
		);
	}

	public void Restart()
	{
		gameObject.transform.position = new Vector2(-2.32f, -2.23f);
	}
}
