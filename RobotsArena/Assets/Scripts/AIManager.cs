using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour {

	public GameObject AIplayer;
	public GameObject EnemyPlayer;
	float searchDistance = 1f;

	float KeepDists = 4f;
	float CloseDistance = 5f;

	bool[] isDirectionAvailable;
	int numDirections = 4;

	enum DIRECTIONS : int
	{
		Zp = 0,
		Zm = 1,
		Xp = 2,
		Xm = 3
	};

	void Start () 
	{
		isDirectionAvailable = new bool[numDirections];
		for (int i = 0; i < numDirections; i++)
		{
			isDirectionAvailable [i] = true;		}
	}

	void Update () 
	{
		if (GameManager.gameState != 4)
			return;
		
		var pos = AIplayer.transform.position;
		transform.position = pos;
		var pos2 = EnemyPlayer.transform.position; 

		AIplayer.transform.LookAt (EnemyPlayer.transform.position);

		float diffX = pos.x - pos2.x;
		float diffZ = pos.z - pos2.z;

		Debug.Log ("DifX: " + diffX + " DifZ: " + diffZ);

		if (diffX > 0)
		{
			if (diffX > CloseDistance)
			{
				if (isDirectionAvailable [(int)DIRECTIONS.Xm])
				{
					MoveX (-1f);
				}
			}
			if (diffX < KeepDists)
				MoveX (1f);
		}
		else
		{
			if (Mathf.Abs(diffX) > CloseDistance)
			{
				if (isDirectionAvailable [(int)DIRECTIONS.Xp])
				{
					MoveX (1f);
				}
			}
			if (Mathf.Abs(diffX) < KeepDists)
				MoveX (-1f);
		}

		if (diffZ > 0)
		{
			if (diffZ > CloseDistance)
			{
				if (isDirectionAvailable [(int)DIRECTIONS.Zp])
				{
					MoveZ (-1f);
				}
			}
			if (diffZ < KeepDists)
				MoveZ (1f);
		}
		else
		{
			if (Mathf.Abs(diffZ) > CloseDistance)
			{
				if (isDirectionAvailable [(int)DIRECTIONS.Zm])
				{
					MoveZ (1f);
				}
			}
			if (Mathf.Abs(diffZ) < KeepDists)
				MoveZ (-1f);
		}
		


	}

	public void DirectionUnavailable(int directionIndex)
	{
		isDirectionAvailable [directionIndex] = false; 
	}

	public void DirectionAvailable(int directionIndex)
	{
		isDirectionAvailable [directionIndex] = true; 
	}

	void MoveX(float dir)
	{
		var pos = AIplayer.transform.position;
		var pos2 = EnemyPlayer.transform.position; 

		pos.x += dir * Time.deltaTime;

		AIplayer.transform.position = pos;
		transform.position = pos;
	}

	void MoveZ(float dir)
	{
		var pos = AIplayer.transform.position;
		var pos2 = EnemyPlayer.transform.position; 

		pos.z += dir * Time.deltaTime;

		AIplayer.transform.position = pos;
		transform.position = pos;
	}
}
