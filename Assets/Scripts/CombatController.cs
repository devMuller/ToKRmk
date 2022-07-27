using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
	[SerializeField] GameObject PlayerWeapon;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			PlayerWeapon.GetComponent<Animator>().SetTrigger("AttackUp");
		}
	}
}
