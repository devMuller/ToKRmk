using UnityEngine;

public class BookController : MonoBehaviour
{
	public bool newContent;

	public int pagesUnlocked;

	public GameObject icon;

	public void NewContent(int newPagesCount)
	{
		newContent = true;
		pagesUnlocked = newPagesCount;
		icon.SetActive(true);
}
}
