using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] GameObject transition;
	public bool nextLevel = true;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			if (nextLevel)
				LoadNextLevel();
			else
				LoadPreviousLevel();
		}
	}

	public void LoadNextLevel()
	{
		Animation anim = Instantiate(transition).GetComponentInChildren<Animation>();
		StartCoroutine(LoadLevel(anim, SceneManager.GetActiveScene().buildIndex + 1));

	}

	public void LoadPreviousLevel()
	{
		Animation anim = Instantiate(transition).GetComponentInChildren<Animation>();
		StartCoroutine(LoadLevel(anim, SceneManager.GetActiveScene().buildIndex - 1));
	}

	private IEnumerator LoadLevel(Animation animation, int levelIndex)
	{
		do
		{
			yield return null;
		} while (animation.isPlaying);
		SceneManager.LoadScene(levelIndex);
	}
}
