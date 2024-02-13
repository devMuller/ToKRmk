using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject tipBook;
	public GameObject inventary;
	public static bool tipBookCanInteract;

	private void Update()
	{
		if(tipBook.activeSelf || inventary.activeSelf)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Tab) && tipBookCanInteract)
		{
			tipBook.SetActive(!tipBook.activeSelf);
		}

		if(Input.GetKeyDown(KeyCode.Escape) && tipBook.activeSelf)
		{
			tipBook.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.I)){
			inventary.SetActive(!inventary.activeSelf);
		}
	}
}
