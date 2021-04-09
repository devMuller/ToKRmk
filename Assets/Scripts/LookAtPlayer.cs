using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	Transform player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		if (player.position.x > this.transform.position.x)
		{ 
			GetComponentInChildren<SpriteRenderer>().flipX = false;
		}
		else
		{
			GetComponentInChildren<SpriteRenderer>().flipX = true;
		}
	}
}
