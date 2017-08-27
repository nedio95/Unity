using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LowerBody : MonoBehaviour {

	public bool isPlayer;
	public int joystickIndex;
	public GameObject gameManager;
	public GameObject otherRobot;

	float Rotation_Speed;
	float Movement_Speed;


	int bulletClipMax = 20;
	float ReloadTimeMax = 3f;
	float bulletSpacingMax = 0.05f;
	int bulletClipCurrent;
	float ReloadTimeCurrent;
	float bulletSpacing;
	public Text bulletCounterText;
	public GameObject LazerSight;

	bool colliding;

	public GameObject muzzle;
	public GameObject bullet;

	public Text roboHealthText;
	int robotHealth = 100;


	// Use this for initialization
	void Start () 
	{
		Rotation_Speed = 50f;
		Movement_Speed = 100f;
		int bulletClipCurrent = bulletClipMax;
		float ReloadTimeCurrent = ReloadTimeMax;
		float bulletSpacing = bulletSpacingMax;
	}
		
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Bullet"))
		{
		//	Debug.Log ("Hit by bulet");
			robotHealth -= 1;
			roboHealthText.text = "Health: " + robotHealth;

			if (robotHealth < 1)
				gameManager.SendMessage("GameLostBy" , joystickIndex, SendMessageOptions.RequireReceiver);
		}
		else
		{
		//	Debug.Log ("NOT Hit by bulet");
			colliding = true;
		}
	//	Debug.Log (" Hit anythung");
	//	colliding = true;

	}

	void OnCollisionExit(Collision col)
	{
		if (!col.gameObject.CompareTag ("Bullet"))
		colliding = false;
	}

	void FixedUpdate ()
	{
		if (GameManager.gameState != 4)
			return;
		
		var pos = gameObject.transform.position;
		pos.y = 1f;
		gameObject.transform.position = pos;

		var rotation = gameObject.transform.localRotation;
		rotation.x = 0f;
		rotation.z = 0f;
		gameObject.transform.localRotation = rotation;

		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero; 

		if (isPlayer)
			ControlledByPlayer ();
		else
			ControlledByAI ();
	}



	void ControlledByAI()
	{
		int layerMask = 1 << 9;
		layerMask += 1 << 10;

		bool doIShoot = false;

		RaycastHit hit ;
		//		Ray ray = new Ray ();
		//RaycastHit hit = Physics.Raycast(transform.position, transform.forward, 2, layerMask );

		if (Physics.Raycast (LazerSight.transform.position, LazerSight.transform.forward, out hit, 50f, layerMask)) 
		{
			if (hit.collider) 
			{
				//Debug.Log ("Something");
				if (hit.collider.gameObject == otherRobot)
				{
					//Debug.Log ("Other robot hit");
					doIShoot = true;
				}
			}
		}

		Shoot (doIShoot);
	}

	void ControlledByPlayer()
	{
		float x = Input.GetAxis ("J" + joystickIndex + "Hor");
		float z = Input.GetAxis ("J" + joystickIndex + "Ver");
		float r = Input.GetAxis ("J" + joystickIndex + "HorR");

		if (Mathf.Abs (x) < 0.1f)
			x = 0f;
		if (Mathf.Abs (z) < 0.1f)
			z = 0f;
		if (Mathf.Abs (r) < 0.1f)
			r = 0f;

		GetComponent<Rigidbody> ().velocity = (transform.forward * z + transform.right * x) * Movement_Speed * Time.deltaTime;

		transform.Rotate (Vector3.up * Rotation_Speed * r * Time.deltaTime);

		Shoot (false);
	}

	void Shoot(bool shoot)
	{
		if (bulletClipCurrent > 0)
		{
			if ((Input.GetKey ("joystick " + joystickIndex +" button 7")) || (shoot) )
			{
				if (bulletSpacing <= 0)
				{
					bulletSpacing = bulletSpacingMax;
					bulletClipCurrent--;
					bulletCounterText.text = "Bullets: " + bulletClipCurrent;
					Instantiate(bullet, muzzle.transform.position, transform.rotation);
				}
				else
					bulletSpacing -= Time.deltaTime;
				//	Debug.Log (bulletSpacing);
			}
		}
		else
		{

			if (ReloadTimeCurrent >= 0)
			{
				ReloadTimeCurrent -= Time.deltaTime;
				bulletCounterText.text = "RELOADING";
				bulletCounterText.color = new Color (255, 0f, 0f);
				LazerSight.SetActive (false);
			}
			else
			{
				bulletClipCurrent = bulletClipMax;
				ReloadTimeCurrent = ReloadTimeMax;
				bulletCounterText.text = "Bullets: " + bulletClipCurrent;
				bulletCounterText.color = new Color (0f, 0f, 0f);
				LazerSight.SetActive (true);
			}

		}
	}
}
