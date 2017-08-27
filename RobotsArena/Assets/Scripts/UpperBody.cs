using UnityEngine;
using System.Collections;

public class UpperBody : MonoBehaviour {

	public KeyCode LeftMB;
	public KeyCode RightMB;
	public GameObject LeftBarrel;
	public GameObject RightBarrel;
	public GameObject LowerBody;
	public GameObject ShotBullet;
	
	private Vector3 mousePos;
	private Vector3 screenPos;
	
	void Start ()
	{
		
	}
	
	void Update () 
	{
		Rotation ();
		var LastBarrelUsed = 0;
		if (Input.GetMouseButton (0)) 
		{
			Instantiate(ShotBullet, LeftBarrel.transform.position, transform.rotation);
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			Instantiate(ShotBullet, RightBarrel.transform.position, transform.rotation);
		}
	}
	
	
	void Rotation()
	{
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitdist = 0.0f;
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
		}
	}
}
