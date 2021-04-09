using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    Animation anim;

	private void Start()
	{
		anim = GetComponentInChildren<Animation>();
	}

	void Update()
    {
        if(!anim.isPlaying)
		{
			Destroy(gameObject, 0.15f);
		}
    }
}
