using UnityEngine;
using System.Collections;

public class Cube_Background : MonoBehaviour {

	float targetY;
	float Speed;

	void Start()
	{
		targetY = -transform.position.y;
		Speed = Random.Range (2f, 4f);
	}

	void Update()
	{
		var pos = transform.position;

		if (targetY > 0)
		{
			if (pos.y > targetY)
			{
				Destroy (gameObject);
			}
			else
			{
				pos.y += Speed * Time.deltaTime; 
				transform.position = pos;
			}	 
		}
		else
		{
			if (pos.y < targetY)
			{
				Destroy (gameObject);
			}
			else
			{
				pos.y -= Speed * Time.deltaTime; 
				transform.position = pos;
			}	 
		}
	}
}
