using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	float speed = 5f;
	float turnSpeed = 25f;
	
	void Update ()
	{
		//====
		// LEFT THUMBSTICK
		//====

		float x = Input.GetAxis ("J1Hor");
		float y = Input.GetAxis ("J1Ver");

		//====
		// RIGHT THUMBSTICK
		//====

		float x2 = Input.GetAxis("J1HorR");
		float y2 = Input.GetAxis("J1VerR");

		//====
		// L2 & R2
		//====

		if (Input.GetAxis ("J1L2") != 0)
		if (Input.GetAxis ("J1L2") != -1)
			Debug.Log ("L2: " + Input.GetAxis ("J1L2"));

		if (Input.GetAxis ("J1R2") != 0)
		if (Input.GetAxis ("J1R2") != -1)
			Debug.Log ("R2: " + Input.GetAxis ("J1R2"));

		//====
		// Dpad
		//====

		if (Input.GetAxis ("J1DpadHor") != 0)
				Debug.Log ("Dpad Horizontal: " + Input.GetAxis ("J1DpadHor"));

		if (Input.GetAxis ("J1DpadVer") != 0)
			Debug.Log ("Dpad Vertical: " + Input.GetAxis ("J1DpadVer"));

		//Square
		if (Input.GetKey ("joystick 1 button 0"))
			Debug.Log ("Sqr");

		//Cross
		if (Input.GetKey ("joystick 1 button 1"))
			Debug.Log ("X");

		//Circle
		if (Input.GetKey ("joystick 1 button 2"))
			Debug.Log ("Cir");

		//Triangle
		if (Input.GetKey ("joystick 1 button 3"))
			Debug.Log ("Tri");
		//====
		// L & R 
		//====
		if (Input.GetKey ("joystick 1 button 4"))
			Debug.Log ("L1");

		if (Input.GetKey ("joystick 1 button 5"))
			Debug.Log ("R1");

		if (Input.GetKey ("joystick 1 button 6"))
			Debug.Log ("L2");

		if (Input.GetKey ("joystick 1 button 7"))
			Debug.Log ("R2");

		if (Input.GetKey ("joystick 1 button 10"))
			Debug.Log ("L3");
		
		if (Input.GetKey ("joystick 1 button 11"))
			Debug.Log ("R3");


		//====
		// Touchpad
		//====
		if (Input.GetKey ("joystick 1 button 13"))
			Debug.Log ("TouchPad");

		//====
		// Menus
		//====

		if (Input.GetKey ("joystick 1 button 8"))
			Debug.Log ("Share");
		
		if (Input.GetKey ("joystick 1 button 9"))
			Debug.Log ("Options");

		if (Input.GetKey ("joystick 1 button 12"))
			Debug.Log ("PS");

		/*
		//====
		//Movement - Left thumb
		//====

		x = x * Time.deltaTime * speed;
		y = y * Time.deltaTime * speed;
		transform.Translate(x, y,0f);

		//====
		//Rotation - Right thumb
		//===

		x2 = x2 * Time.deltaTime * turnSpeed;
		y2 = y2 * Time.deltaTime * turnSpeed;
		
		transform.Rotate (Vector3.up * x2);
		transform.Rotate (Vector3.right * y2);
		*/
	}
}
