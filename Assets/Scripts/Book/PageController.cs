using UnityEngine;

public class PageController : MonoBehaviour
{
	int page = 0;

	public BookController book;

	public PageMananger pages;
	public GameObject leftPage;
	public GameObject rightPage;

	private void OnDisable()
	{
		DeletePages();
	}

	private void OnEnable()
	{
		DeletePages();
		GenPage();
	}

	private void DeletePages()
	{
		GameObject[] pages = GameObject.FindGameObjectsWithTag("Page");
		foreach(GameObject page in pages)
		{
			Destroy(page);
		}
	}

	private void GenPage()
	{
		if (book.pagesUnlocked >= page)
			Instantiate(pages.pages[page], leftPage.transform);
		if (book.pagesUnlocked >= page + 1)
			Instantiate(pages.pages[page + 1], rightPage.transform);
	}

	public void NextPage()
	{
		DeletePages();
		if (page + 2 < book.pagesUnlocked)
			page += 2;
		GenPage();
	}

	public void PreviousPage()
	{
		DeletePages();
		if (page - 2 >= 0)
			page -= 2;
		GenPage();
	}


	private void Update()
	{
		if (this.gameObject.activeSelf)
		{
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				PreviousPage();
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				NextPage();
			}
		}
	}

}
