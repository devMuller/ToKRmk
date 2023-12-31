using UnityEngine;
using TMPro;
using System.Collections;

public class Puzzle1 : MonoBehaviour
{
	public bool puzzle1Completed = false;
	public static bool puzzleFail = false;

	TorchController[] torchs;
	DoorController door;
	public NPCController charlesIA;

	public TMP_Text[] torchNumbers;
	int[] numbers = new int[4];

	static int puzzleStage = 0;
	static int[] playerNumbers = new int[4];

	public static DialogueMananger dialogues;
	public static int dialogue = 0;
	int specialDialogue = 0;
	new int name = 0;

	static string story;

	public static bool nextText = false;

	public bool w, a, s, d;
	bool WASD = false;
	Animator[] animKeys = new Animator[4];

	public float typeSpeed = 0.025f;
	float multiplierSpeed = 1;

	public GameObject exclamation;
	public GameObject charles;
	public CircleCollider2D charlesCollider;
	int finalStage = 0;
	float time = 0;

	bool[] stage = new bool[2];

	public BookController book;

	private void Start()
	{
		door = GameObject.FindObjectOfType<DoorController>().GetComponent<DoorController>();
		torchs = GetComponentsInChildren<TorchController>();
		dialogues = GameObject.FindObjectOfType<DialogueMananger>().GetComponent<DialogueMananger>();
		TypeWriter();
		GenNumber();
	}

	private void Update()
	{
		dialogues.name.text = dialogues.names[name];

		if (!puzzle1Completed)
		{
			if (dialogue > 1)
			{
				name = 1;
			}

			if (Input.GetKey(KeyCode.Z) && !nextText)
			{
				multiplierSpeed = 0.5f;
			}
			else
			{
				multiplierSpeed = 1;
			}

			if (dialogue == 3 && nextText)
			{
				MovementController.canMove = true;
			}

			if (Input.GetKeyDown(KeyCode.Z) && nextText == true && dialogue != 3 && dialogue != 4 && dialogue != 10 && dialogue < 13 || Input.GetKeyDown(KeyCode.Z) && puzzleFail)
			{
				if (!puzzleFail)
				{
					dialogue++;
					TypeWriter();
				}
				else
				{
					dialogues.dialogueBox.SetActive(false);
					puzzleFail = false;
				}
				DisableKeys();
			}
			else if (Input.GetKeyDown(KeyCode.E) && nextText == true && dialogue == 4)
			{
				dialogue++;
				TypeWriter();
				DisableKeys();
			}
			else if(charlesIA.playerIn && nextText && dialogue == 5)
			{
				dialogue++;
				TypeWriter();
				DisableKeys();
			}
			else if(Input.GetKeyDown(KeyCode.Tab) && nextText == true && dialogue == 6)
			{
				dialogue++;
				TypeWriter();
				DisableKeys();
			}

			if (nextText && puzzleFail || dialogue != 3 && dialogue != 4 && dialogue != 10 && dialogue != 5 && dialogue != 6 && nextText && dialogue < 13)
			{
				dialogues.keys[0].SetActive(true);
			}
			else if (nextText && dialogue == 3 && !WASD)
			{
				WASD = true;
				for (int i = 1; i <= 4; i++)
				{
					dialogues.keys[i].SetActive(true);
					animKeys[i - 1] = dialogues.keys[i].GetComponent<Animator>();
				}
			}
			else if (nextText && dialogue == 4)
			{
				dialogues.keys[5].SetActive(true);
			}
			else if(nextText && dialogue == 6 && book.newContent == false)
			{
				UIController.tipBookCanInteract = true;
				book.NewContent(7);
				dialogues.keys[6].SetActive(true);
			}

			if (puzzleFail == false)
				dialogues.textSize.text = dialogues.dialogues[dialogue];
			else
				dialogues.textSize.text = dialogues.specialDialogues[specialDialogue];

			if (dialogue == 3 && nextText == true)
			{
				if (Input.GetKeyDown(KeyCode.W))
				{
					w = true;
					animKeys[0].SetBool("pressed", true);
				}
				if (Input.GetKeyDown(KeyCode.A))
				{
					a = true;
					animKeys[1].SetBool("pressed", true);
				}
				if (Input.GetKeyDown(KeyCode.S))
				{
					s = true;
					animKeys[2].SetBool("pressed", true);
				}
				if (Input.GetKeyDown(KeyCode.D))
				{
					d = true;
					animKeys[3].SetBool("pressed", true);
				}

				if (w == true && a == true && d == true && s == true)
				{
					dialogue++;
					TypeWriter();
					DisableKeys();
				}
			}

			if (puzzleStage == 4)
			{
				if (playerNumbers[0] < playerNumbers[1] && playerNumbers[1] < playerNumbers[2] && playerNumbers[2] < playerNumbers[3])
				{
					if (dialogue == 13)
						puzzle1Completed = true;

					if (dialogue == 10)
					{
						dialogues.dialogueBox.SetActive(true);
						dialogue++;
						nextText = false;
						TypeWriter();
					}
				}
				else
				{
					puzzleFail = true;

					TypeWriter();
					nextText = false;

					puzzleStage = 0;
					playerNumbers = new int[4];
					GenNumber();
					foreach (TorchController torch in torchs)
					{
						torch.unlit = false;
					}
				}
			}
		}
		else
		{
			door.canInteratic = true;
			foreach (TorchController torch in torchs)
			{
				Destroy(torch.numberGameObject);
				torch.unlit = false;
			}

			if (door.closed == false)
			{
				if (finalStage == 0)
				{
					if (time == 0)
					{
						time = Time.time;
						MovementController.canMove = false;
					}
					if (Time.time - time > 0.25f && stage[0] == false)
					{
						stage[0] = true;
						exclamation.SetActive(true);
						dialogues.textSize.fontSizeMax = 80;
						dialogues.dialogueBox.SetActive(true);
						charlesCollider.enabled = true;
						if (dialogue == 13)
						{
							dialogue++;
							nextText = false;
							dialogues.textSize.text = dialogues.dialogues[dialogue];
							TypeWriter();
						}
						finalStage++;
						time = 0;
					}
				}
				else if (finalStage == 1)
				{
					if (time == 0)
						time = Time.time;
					else if (Time.time - time > 1f && stage[1] == false)
					{
						stage[1] = true;
						exclamation.SetActive(false);
						dialogues.dialogueBox.SetActive(false);
						finalStage++;
					}
				}
				else if (finalStage == 2)
				{
					charles.transform.position = Vector2.MoveTowards(charles.transform.position, new Vector2(0, 10), 5f * Time.deltaTime);

					if (charles.transform.position.y >= 9.5f)
					{
						finalStage++;
					}
				}
				else if (finalStage == 3)
				{
					Destroy(charles);
					MovementController.canMove = true;
				}
			}
		}
	}

	public static void PlayerNumber(int torchNumber)
	{
		playerNumbers[puzzleStage] = torchNumber;
		puzzleStage++;
	}

	private void GenNumber()
	{
		for (int i = 0; i < 4; i++)
		{
			bool allDifferent;
			do
			{
				allDifferent = true;
				numbers[i] = Random.Range(1, 9);
				for (int j = 0; j < 4; j++)
				{
					if (j != i)
					{
						if (numbers[i] == numbers[j])
						{
							allDifferent = false;
						}
					}
				}
			} while (!allDifferent);
		}
		for (int i = 0; i < 4; i++)
		{
			torchNumbers[i].text = numbers[i].ToString();
		}
	}

	public void TypeWriter()
	{
		nextText = false;
		if (dialogue == 10 || dialogue == 13)
		{
			dialogues.dialogueBox.SetActive(false);
		}

		if (!puzzleFail)
			story = dialogues.dialogues[dialogue];
		else
		{
			dialogues.dialogueBox.SetActive(true);
			story = dialogues.specialDialogues[0];
		}

		dialogues.text.text = "";
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			dialogues.text.text += c;
			yield return new WaitForSeconds(multiplierSpeed * typeSpeed);
		}
		nextText = true;
	}

	void DisableKeys()
	{
		for (int i = 0; i < dialogues.keys.Length; i++)
		{
			dialogues.keys[i].SetActive(false);
		}
	}
}
