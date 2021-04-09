using UnityEngine;
using TMPro;

public class DialogueMananger : MonoBehaviour
{
	public GameObject dialogueBox;

	public string[] names;
	public string[] dialogues;

	public string[] specialDialogues;

	public GameObject[] keys;

	public new TMP_Text name;
	public TMP_Text text;
	public TMP_Text textSize;

	private void Update()
	{
		text.fontSize = textSize.fontSize;
	}
}
