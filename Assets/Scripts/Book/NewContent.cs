using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewContent : MonoBehaviour
{
	public BookController book;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab) && book.newContent == true)
		{
			book.newContent = false;
			gameObject.SetActive(false);
		}
	}
}
