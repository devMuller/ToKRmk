using UnityEngine;

public class CombatController : MonoBehaviour
{
	[SerializeField] GameObject PlayerWeaponPivot;

	private Animator AnimPWP;
	public float AttackCoolDown = .5f;
	public float AttackDuration = 1f;

	float AttackTime = 0f;

	public float AttackDamage = 2f;

	private void Start()
	{
		AnimPWP = PlayerWeaponPivot.GetComponent<Animator>();
	}

	private void Update()
	{
		if (Time.time - AttackTime > AttackCoolDown)
		{

			if (Input.GetKey(KeyCode.UpArrow))
			{
				Attack("AttackUp");
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				Attack("AttackDown");
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				Attack("AttackLeft");
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				Attack("AttackRight");
			}
		}

		if(AttackTime != 0f) { 
			if(AnimPWP.GetCurrentAnimatorStateInfo(0).normalizedTime > AttackDuration)
			{
				PlayerWeaponPivot.SetActive(false);
			}
		}
	}

	private void Attack(string TriggerName)
	{
		PlayerWeaponPivot.SetActive(true);
		AnimPWP.SetTrigger(TriggerName);
		AttackTime = Time.time;
	}
}
