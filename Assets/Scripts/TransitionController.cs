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
	[SerializeField] GameObject image;
	[SerializeField] GameObject text;


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

		while (!operation.isDone)
		{
			yield return new WaitForSecondsRealtime(0.5f);
			Color startcolor = image.GetComponent<Image>().color;
			Color endcolor = startcolor;
			endcolor.a = 255;

			float t = 0.0f;
			float duration = 150f;
			while (image.GetComponent<Image>().color.a < 250)
			{
				text.GetComponent<TMP_Text>().color = Color.Lerp(startcolor, endcolor, t);
				image.GetComponent<Image>().color = Color.Lerp(startcolor, endcolor, t);
				if (t < 1)
				{
					t += Time.deltaTime / duration;
				}
				yield return null;
			}
			yield return null;
		}
	}

	IEnumerator LoadingText()
	{
		while(true){
			text.GetComponent<TMP_Text>().text = "Carregando.";
			yield return new WaitForSecondsRealtime(0.5f);
			text.GetComponent<TMP_Text>().text = "Carregando..";
			yield return new WaitForSecondsRealtime(0.5f);
			text.GetComponent<TMP_Text>().text = "Carregando...";
			yield return new WaitForSecondsRealtime(0.5f);
		}
	}
}
