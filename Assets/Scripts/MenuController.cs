using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	[SerializeField] float speed = 10f;
	[SerializeField] GameObject transition;

	Transform mainCamera;

	Vector2 Position;
	bool vertical;

	private void Start()
	{
		mainCamera = Camera.main.transform;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && Position == Vector2.zero)
		{
			Exit();
		}

		if (Input.GetKeyDown(KeyCode.Escape) && Position != Vector2.zero)
		{
			MainMenu(mainCamera.position.x != 0);
		}
	}

	private void FixedUpdate()
	{
		if (Position != null && Camera.main.transform.position != new Vector3(Position.x, Position.y, 0))
			if (vertical)
				mainCamera.position = Vector2.MoveTowards(Camera.main.transform.position, Position, (speed * 1.5f) * Time.deltaTime);
			else
				mainCamera.position = Vector2.MoveTowards(Camera.main.transform.position, Position, (speed * 2) * Time.deltaTime);

	}

	//Start Game
	public void NewGame()
	{
		TransitionController obj = Instantiate(transition).GetComponentInChildren<TransitionController>();
		obj.nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
	}


	//Navegation 
	public void SettingsMenu()
	{
		vertical = true;
		Position = new Vector2(0f, 4.5f);
	}

	public void MainMenu(bool _vertical)
	{
		vertical = _vertical;
		Position = Vector2.zero;
	}

	public void CreditsMenu()
	{
		vertical = true;
		Position = new Vector2(0, -4.5f);
	}

	public void PlayMenu()
	{
		vertical = false;
		Position = new Vector2(9f, 0);
	}

	public void Exit()
	{
		Application.Quit();
	}

}
