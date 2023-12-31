using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	public int playerMaxHealth = 6;
	public int playerCurrentHealth;

	public GameObject HealthBar;

	public GameObject[] Hearts = new GameObject[5];

	public float regenCoolDown = 10f;
	public float lastRegen = 0f;

	public float damageCoolDown = 0.5f;
	public float lastDamage = 0f;

	Animator anim;
	public Transform spriteTransform;

	private void Start()
	{
		anim = GetComponentInChildren<Animator>();
		playerCurrentHealth = playerMaxHealth;
		UpdateHealthBar();
		UpdateHealth();
	}

	private void Update()
	{
		if (Time.time - lastRegen > regenCoolDown && playerCurrentHealth < playerMaxHealth)
		{
			lastRegen = Time.time;
			playerCurrentHealth++;
			UpdateHealth();
		}
	}

	void UpdateHealthBar()
	{
		if(playerMaxHealth >= 9)
		{
			Hearts[4].SetActive(true);
		}
		 if (playerMaxHealth >= 7)
		{
			Hearts[3].SetActive(true);
		}
		 if (playerMaxHealth >= 5)
		{
			Hearts[2].SetActive(true);
		}
		 if(playerMaxHealth >= 3)
		{
			Hearts[1].SetActive(true);
		}
		 if(playerMaxHealth >= 1)
		{
			Hearts[0].SetActive(true);
		}
		UpdateHealth();
	}

	void UpdateHealth()
	{
		HealthBar.GetComponent<Animator>().SetInteger("Health", playerCurrentHealth) ;
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
		if (Time.time - lastDamage > damageCoolDown)
		{
			lastDamage = Time.time;
			lastRegen = Time.time;
			anim.SetTrigger("hit");
			playerCurrentHealth--;
			UpdateHealth();
			StartCoroutine("Hit");
			StartCoroutine("Up");
		}
	}

	void RegenHeatlh()
	{

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
