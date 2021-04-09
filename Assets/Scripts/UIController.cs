using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject tipBook;
	public static bool tipBookCanInteract;

	private void Update()
	{
		if(tipBook.activeSelf)
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
	}
}
