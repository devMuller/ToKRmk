using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	public Vector3 moveTo = new Vector3(0, 0, -20f);
	public new Transform camera;
	public float cameraSpeed = 10f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			StartCoroutine(MoveCamera());
		}
	}
	IEnumerator MoveCamera()
	{
		while (camera.position != moveTo)
		{
			MovementController.canMove = false;
			camera.position = Vector3.MoveTowards(camera.position, moveTo, 10f * Time.deltaTime);
			yield return new WaitForFixedUpdate();
		}
		MovementController.canMove = true;
	}
}
