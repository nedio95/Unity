using UnityEngine;
using System.Collections;

public class FemaleBird : MonoBehaviour {

	static float speed = 5.0f;
	static float turnSpeed = 25.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//====
		// LEFT THUMBSTICK
		//====

        //Get input
		float x = Input.GetAxis ("J1Hor");
		float y = Input.GetAxis ("J1Ver");

		//====
		//Movement - Left thumb
		//====

	
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //====
        //Rotation - Right thumb
        //===

        x = x * Time.deltaTime * turnSpeed;
		y = y * Time.deltaTime * turnSpeed;

		transform.Rotate (Vector3.up * x);
		transform.Rotate (Vector3.right * y);

	
	}
}
