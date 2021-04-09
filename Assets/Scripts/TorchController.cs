using UnityEngine;
using TMPro;
public class TorchController : MonoBehaviour
{
	public Animator anim;

	public bool unlit = false;

	bool playerIn = false;

	TMP_Text number;

	public GameObject dialogueBox;

	public GameObject numberGameObject;

	private void Start()
	{
		number = GetComponentInChildren<TMP_Text>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerIn = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerIn = false;
		}
	}

	private void Update()
	{
		anim.SetBool("unlit", unlit);
		if (gameObject.CompareTag("TorchWithNumber"))
			if (Input.GetKeyDown(KeyCode.E) && playerIn && Puzzle1.puzzleFail == false && dialogueBox.activeSelf == false && !unlit)
			{
				unlit = true;
				Puzzle1.PlayerNumber(int.Parse(number.text));
			}
	}
}
