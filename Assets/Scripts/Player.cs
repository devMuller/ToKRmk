using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	public int playerHealth = 6;
	public int playerCurrentHealth;

	public float regenTime = 10f;
	public bool nextRegen = true;

	public float hitTime = 0.5f;
	public bool nextHit = true;

	Animator anim;
	public Transform spriteTransform;

	private void Start()
	{
		anim = GetComponentInChildren<Animator>();
		playerCurrentHealth = playerHealth;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Damage();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Damage();
		}
	}

	void Damage()
	{
		if (nextHit)
		{
			nextHit = false;
			anim.SetTrigger("hit");
			playerCurrentHealth--;
			StartCoroutine("Hit");
			StartCoroutine("Up");
		}
	}

	IEnumerator Hit()
	{
		yield return new WaitForSeconds(hitTime);
		nextHit = true;
	}

	IEnumerator Up()
	{
		do
		{
			spriteTransform.localPosition = Vector2.MoveTowards(spriteTransform.localPosition, new Vector2(0, 0.6f), 2.5f * Time.deltaTime);
			Debug.Log("aa");
		} while (spriteTransform.localPosition.y < 0.5f);
		yield return new WaitForSeconds(0);
		StartCoroutine("Down");
	}

	IEnumerator Down()
	{
		do
		{
			spriteTransform.localPosition = Vector2.MoveTowards(spriteTransform.localPosition, new Vector2(0, 0), 2.5f * Time.deltaTime);
		} while (spriteTransform.localPosition.y == 0);
		yield return new WaitForSeconds(0);
	}
}
