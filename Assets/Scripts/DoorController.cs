using UnityEngine;

public class DoorController : MonoBehaviour
{
	public Sprite closedSprite;
	public Sprite openedSprite;

	public SpriteRenderer door;
	public new BoxCollider2D collider;

	bool playerIn = false;

	public bool closed = true;
	public bool canInteratic = false;

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
		if(playerIn && canInteratic && Input.GetKeyDown(KeyCode.E))
		{
			closed = false;
		}

		if (closed)
		{
			door.sprite = closedSprite;
			collider.enabled = true;
		}
		else
		{
			door.sprite = openedSprite;
			collider.enabled = false;
		}
	}


}
