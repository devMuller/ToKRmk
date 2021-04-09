using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	public float spawnTime = 1f;

	public GameObject enemy;

	public bool canSpawn;
	public bool nextSpawn = true;
	public float moveSpeed = 5f;


	public bool moveFoward;

	//[HideInInspector]
	public Vector3 moveTo;

	private void Update()
	{
		if(canSpawn && nextSpawn)
		{
			nextSpawn = false;
			StartCoroutine("Spawn");
		}
	}

	IEnumerator Spawn()
	{
		GameObject _enemy = Instantiate(enemy, transform);

		if(moveFoward)
		{
			MoveFoward move = _enemy.GetComponent<MoveFoward>();
			move.moveTo = moveTo;
			move.moveSpeed = moveSpeed;
		}

		yield return new WaitForSeconds(spawnTime);
		nextSpawn = true;
	}
}
