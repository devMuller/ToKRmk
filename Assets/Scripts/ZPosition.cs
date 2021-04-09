using UnityEngine;

public class ZPosition : MonoBehaviour
{
    Transform player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
    {
		if(this.transform.position.y > player.position.y)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
		}
		else
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
		}
	}
}
