using UnityEngine;
using System.Collections;

public class LaserSight : MonoBehaviour {

	LineRenderer lineRender;
	float distMax = 50;

	enum Layers
	{
		
	};

	void Start () 
	{
		lineRender = GetComponent<LineRenderer>(); 
	}

	void Update () 
	{
		int layerMask = 1 << 9;
		layerMask += 1 << 10;

		RaycastHit hit ;
//		Ray ray = new Ray ();
		//RaycastHit hit = Physics.Raycast(transform.position, transform.forward, 2, layerMask );

		if (Physics.Raycast (transform.position, transform.forward, out hit, distMax, layerMask)) 
		{
			if (hit.collider) 
			{
				lineRender.SetPosition (1, new Vector3 (0, 0, hit.distance));
			}
		} else 
		{
			lineRender.SetPosition (1, new Vector3 (0, transform.position.y, distMax));
		}
	}
}
