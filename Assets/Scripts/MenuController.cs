using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Vector2 Position;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && Position == Vector2.zero)
		{
			Exit();
		}

		if (Input.GetKeyDown(KeyCode.Escape) && Position != Vector2.zero)
		{
			MainMenu();
		}
	}

	private void FixedUpdate()
	{
		if (Position != null && Camera.main.transform.position != new Vector3(Position.x, Position.y, 0))
			Camera.main.transform.position = Vector2.MoveTowards(Camera.main.transform.position, Position, 10f * Time.deltaTime);
	}

	public void SettingsMenu()
	{
		Position = new Vector2(0f, 4.5f);
	}

	public void MainMenu()
	{
		Position = Vector2.zero;
	}

	public void CreditsMenu()
	{
		Position = new Vector2(0, -4.5f);
	}

	public void PlayMenu()
	{
		Position = new Vector2(9f, 0);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
