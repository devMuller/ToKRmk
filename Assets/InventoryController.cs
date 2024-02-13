using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
	public GameObject[] slots;  

	public void ChangeWeapon(Sprite sprite, string weaponName)
	{
		slots[0].GetComponentsInChildren<Image>()[1].sprite = sprite;
		slots[0].GetComponentInChildren<TMP_Text>().text = weaponName;
	}

}
