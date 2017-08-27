using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public static float speed = 2.5f;
	public static bool ready = false;

	Vector3 TargetPos;
	public bool steppedOn = false;
	bool moving = true;
	bool downStance = true;
	bool Elevation=false;

	Vector3 StartPosition;

	void Start () 
	    {
		Elevation = false;
		//LevelManager.CubesPool[LevelManager.CubesCount] = gameObject;
		gameObject.SetActive (false);
		StartPosition = transform.position;
		TargetPos = new Vector3 (StartPosition.x, 0, StartPosition.z);
		}

	void Update () 
	{ 
		/*
		if (GameManager.gameState == 4) 
		{
			if (!Elevation)
			{
				Debug.Log ("Elevation Staring weeeee");
				Invoke ("StartElevating", 0.1f);
				Elevation = true;
			}
		}
		*/

		if (GameManager.gameState > 1) 
		{
			//if (LevelManager.gettingInPlace == false)
			//	Debug.Log (Elevation);
			if (LevelManager.gettingInPlace == false && Elevation == false) 

			{
				//Debug.Log ("Elevation Staring weeeee");
				Invoke ("StartElevating", 0.1f);
				Elevation = true;
			}
		}

		if (!moving)
			return;

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, TargetPos, step);
		if (transform.position == TargetPos) 
		{
			moving = false;

		}


	}

	public void StartElevating()
	{
	//	Debug.Log("Start Elevating Invoked");
		InvokeRepeating("ChoseCubes",1f,10f);
		speed = 0.2f;
	}


	void ChoseCubes()
	{
	//	Debug.Log("Chose Cube Invoked");
		if (!steppedOn) 
		{
			int randChance = 15;
			int random = Random.Range(0,100);
			if( !downStance && random < randChance*4)
			{
				moving = true;
				TargetPos.y = 0;
				downStance = true;

			//	Debug.Log("Going DOOOOOOWN");
			}
			else if (random < randChance)
			{
				moving = true;
				TargetPos.y = 1;
				downStance = false;
			//	Debug.Log("Going UPP");

			}
		}
	}
}