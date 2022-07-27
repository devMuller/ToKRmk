using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] GameObject transition;
	[SerializeField] bool nextLevel;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (nextLevel)
				LoadNextLevel();
			else
				LoadPreviousLevel();
		}
	}

	public void LoadNextLevel()
	{
		TransitionController obj = Instantiate(transition).GetComponentInChildren<TransitionController>();
		obj.nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

	}

	public void LoadPreviousLevel()
	{
		TransitionController obj = Instantiate(transition).GetComponentInChildren<TransitionController>();
		obj.nextLevel = SceneManager.GetActiveScene().buildIndex - 1;
	}
}
