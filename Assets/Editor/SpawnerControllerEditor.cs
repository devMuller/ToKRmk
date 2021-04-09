using System;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnerController))]
public class SpawnerControllerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SpawnerController spawner = (SpawnerController)target;
				
		if (spawner.moveFoward)
		{

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("This Vector X"))
			{
				spawner.moveTo.x = spawner.transform.position.x;
			}

			if (GUILayout.Button("This Vector Y"))
			{
				spawner.moveTo.y = spawner.transform.position.y;
			}
			GUILayout.EndHorizontal();
		}
	}
}
