using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestConfig : MonoBehaviour
{

	public float lootType = 0f;

	public Sprite lootSprite;

    public string Loot;

    public bool ChestCanBeOpen = false;
	public bool ChestOpen = false;
	public GameObject ChestItemDisplay;

	Animator ChestAnimator;

	public bool ChestEmpty = false;

	public InventoryController PlayerInventory;

	public GameObject Player;
	public GameObject PlayerWeapon;
	public GameObject PlayerItemDisplay;
	public InventoryController Inventory;

	bool playerIn = false;
	private void Start()
	{
		ChestItemDisplay.GetComponent<SpriteRenderer>().sprite = lootSprite;
		ChestAnimator = GetComponent<Animator>();
	}

	void Update()
    {
		if (ChestOpen)
		{
			if (ChestAnimator.GetCurrentAnimatorStateInfo(0).IsName("Opened"))
			{
				ChestItemDisplay.SetActive(true);
			}
		}

		if (playerIn)
		{
			if (!ChestOpen)
			{
				if (ChestCanBeOpen && Input.GetKeyDown(KeyCode.E))
				{
					ChestOpen = true;
					ChestAnimator.SetTrigger("Opening");
				}
			}
			else
			{
				if (!ChestEmpty && Input.GetKeyDown(KeyCode.E) && ChestItemDisplay.activeSelf)
				{
					PlayerItemDisplay.SetActive(true);
					PlayerItemDisplay.GetComponent<SpriteRenderer>().sprite = lootSprite;
					PlayerWeapon.GetComponent<SpriteRenderer>().sprite = lootSprite;
					PlayerInventory.ChangeWeapon(lootSprite, "ARMAAAAA");
					ChestItemDisplay.GetComponent<SpriteRenderer>().sprite = null;
					ChestItemDisplay.SetActive(false);
					ChestAnimator.SetTrigger("Empty");
					ChestEmpty = true;
				}
			}
		}
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

}
