using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
	Animation anim;
	[SerializeField] bool destroyAfterPlaying;

	public int nextLevel;

	bool fadeStarted;
	[SerializeField] Image image;
	[SerializeField] TMP_Text text;

	private void Start()
	{
		anim = GetComponentInChildren<Animation>();
	}

	void Update()
	{
		if (!anim.isPlaying && destroyAfterPlaying)
		{
			Destroy(gameObject, 0.15f);
		}
		else if (!anim.isPlaying && !fadeStarted)
		{
			fadeStarted = true;
			StartCoroutine(LoadLevel());
			StartCoroutine(LoadingText());
		}

	}

	IEnumerator LoadLevel()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel);

		yield return new WaitForSecondsRealtime(0.5f);

		operation.allowSceneActivation = false;

		Color startcolor;
		Color endcolor;
		float t;
		float duration;

		startcolor = new Color(1, 1, 1, 0);
		endcolor = new Color(1, 1, 1, 1);

		t = 0.0f;
		duration = 0.5f;
		while (operation.progress < 0.9f)
		{
			while (image.color.a < 1)
			{
				text.color = Color.Lerp(startcolor, endcolor, t);
				image.color = Color.Lerp(startcolor, endcolor, t);
				if (t < 1)
				{
					t += Time.deltaTime / duration;
				}
				yield return null;
			}
			yield return null;
		}

		startcolor = new Color(1, 1, 1, 1);
		endcolor = new Color(1, 1, 1, 0);

		t = 0f;
		duration = 0.5f;

		while (image.color.a > 0f)
		{
			text.color = Color.Lerp(startcolor, endcolor, t);
			image.color = Color.Lerp(startcolor, endcolor, t);
			if (t < 1)
			{
				t += Time.deltaTime / duration;
			}
			yield return null;
		}
		yield return null;
		operation.allowSceneActivation = true;
	}

	IEnumerator LoadingText()
	{
		while (true)
		{
			text.text = "Carregando";
			yield return new WaitForSecondsRealtime(0.5f);
			text.text = "Carregando.";
			yield return new WaitForSecondsRealtime(0.5f);
			text.text = "Carregando..";
			yield return new WaitForSecondsRealtime(0.5f);
			text.text = "Carregando...";
			yield return new WaitForSecondsRealtime(0.5f);
		}
	}

}
