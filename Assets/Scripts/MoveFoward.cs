using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
	public Vector3 moveTo;
	public float moveSpeed = 5f;

	private void Update()
	{
		if (transform.position == moveTo)
			Destroy(gameObject);
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(this.transform.position, moveTo, moveSpeed * Time.deltaTime);
	}
}
