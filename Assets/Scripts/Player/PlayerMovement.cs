using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 2f;

	private Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if (horizontal > 0)
		{
			animator.Play("MoveRight");
		}
		if (horizontal < 0)
		{
			animator.Play("MoveLeft");
		}
        if (vertical > 0)
		{
			animator.Play("MoveUp");
		}
		if (vertical < 0)
		{
			animator.Play("MoveDown");
		}
		transform.position += new Vector3(horizontal, vertical) * Time.deltaTime * movementSpeed;
	}
}
