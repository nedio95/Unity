using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public GameObject cubePrefab;
	float min = 15;
	float max = 25;
	float maxY = 40;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnCubes", 0.5f, 0.2f);
	}

	void SpawnCubes ()
	{
		for (int i = 0; i < 3; i++)
		{
			SpawnCube (min, max, -max, max);
			SpawnCube (-min, -max, -max, max);
			SpawnCube (-max, max, -min, -max);
			SpawnCube (-max, max, min, max);
		}
	}

	void SpawnCube(float minX, float maxX, float minY, float maxY)
	{
		float X = Random.Range (minX, maxX);
		float Z = Random.Range (minY, maxY);
		float Y;

		int aboveOrBellow = Random.Range (0, 2);
		if (aboveOrBellow == 0)
			Y = -maxY;
		else
			Y = maxY;

		Instantiate (cubePrefab, new Vector3 (X, Y, Z), Quaternion.identity);
	}

}
