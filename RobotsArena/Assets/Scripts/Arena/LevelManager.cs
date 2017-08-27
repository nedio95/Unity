using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject cubePrefab;
	public GameObject cubePrefabFast;
	public GameObject outerCubePrefab;
	public GameObject redCube;
	public Transform spawnObject;
	public int CubesCount = 0;
	public static bool gettingInPlace = true;

	List <GameObject> PoolOfCubes;
	int NumOuter = 0;
	List <GameObject> PoolOfOuterCubes;
	int NumCubes = 0;
		
	int CubeDex;
	const int aLimit = 14;
	const int SideSize = 10;
	int BonesCount=0;
	int NextCountDex;
	int[] TempIndex;

	int LoopDex;
	int OuterDex;
	int TempDex;

	void Start () {
		TempIndex = new int[2];
		gettingInPlace = true;
		PoolOfCubes = new List<GameObject>();
		PoolOfOuterCubes = new List<GameObject>();
		CreateArena ();
	}
		

	//========================================================
	//GAMEPLAY
	//========================================================

	void ElevateCubes()
	{
		int randomChanceElevate = Random.Range(10,20);
		int abc;
	}

	//========================================================
	//ACTIVATING CUBES
	//========================================================


	void ActivateRandomElevation()
	{
		gettingInPlace = false;
		Debug.Log("Level in place: " + gettingInPlace);
	//	InvokeRepeating("ElevateCubes",0f, 10f);
	}

	void Act_OuterCube()
	{
		for (int i = 0; i < 8; i++) 
		{
			PoolOfOuterCubes [TempDex].SetActive (true);
			TempDex++;
		}
		if (TempDex == NumOuter) 
		{
			CancelInvoke();
			TempDex = 0;
			InvokeRepeating("Act_Bones",0.1f,0.1f);
		}

	}

	void Act_Bones()
	{
		for (int i = 0; i < 4; i++) 
		{
			PoolOfCubes [TempDex].SetActive (true);
			TempDex++;
		}
		if (TempDex == BonesCount) 
		{
			CancelInvoke();

			Invoke("Start_Inner",4f);
		}
	}

	void Start_Inner()
	{
		Cube.speed = 10;
		InvokeRepeating("Act_Inner",0.2f,0.2f);
	}
	void Act_Inner()
	{
		for (int i = 0; i < 8; i++) 
		{
			PoolOfCubes [TempDex].SetActive (true);
			TempDex++;
		}
		if (TempDex == NumCubes) 
		{
			CancelInvoke();
			//GameManager.gameState = 1;
			Invoke("ActivateRandomElevation", 5f);
		}
	}

	void Act_Spawners()
	{
	}

	//========================================================
	//CREATING CUBES
	//========================================================
	void MakeNewCube (float x,float z)
	{
		GameObject obj = (GameObject)Instantiate (cubePrefab, new Vector3(x,-10,z), Quaternion.identity);
		NumCubes++;
		PoolOfCubes.Add (obj);
	}

	void MakeNewCube_RandomY(float x, float z)
	{
		int i = NumCubes % 2;
		TempIndex[0]= Random.Range (50, 25);
		TempIndex[1]= Random.Range (-50, -25);
		GameObject obj = (GameObject)Instantiate (cubePrefab, new Vector3(x,TempIndex[i],z), Quaternion.identity);
		NumCubes++;
		PoolOfCubes.Add (obj);
	}

	void MakeNewOuterCube(float x, float z)
	{
		GameObject obj = (GameObject)Instantiate (outerCubePrefab, new Vector3(x,-10,z), Quaternion.identity);
		NumOuter++;
		PoolOfOuterCubes.Add (obj);
	}

	void MakeNewRedCube(float x, float y)
	{
		Instantiate (redCube, new Vector3(x,1,y), Quaternion.identity);
	}

	//========================================================
	//ACTIVATING ARENA
	//========================================================
	
	void CreateArena()
	{
		for (int i = -1; i < 2; i++) {
			MakeNewRedCube (-aLimit, i*aLimit);
			MakeNewRedCube (aLimit, i*aLimit);
		}
		MakeNewRedCube (0, aLimit);
		MakeNewRedCube (0, -aLimit);
		//=====================================
		//OUTER CUBES
		//=====================================
		for(int dex = aLimit-1; dex > 0;dex--)
		{
			MakeNewOuterCube(-aLimit,dex);
			MakeNewOuterCube(aLimit,-dex);
			MakeNewOuterCube(dex,aLimit);
			MakeNewOuterCube(-dex,-aLimit);

			MakeNewOuterCube(aLimit,dex);
			MakeNewOuterCube(-aLimit,-dex);
			MakeNewOuterCube(dex,-aLimit);
			MakeNewOuterCube(-dex,aLimit);
		}
	    TempDex = 0;
		InvokeRepeating ("Act_OuterCube", 0.2f, 0.2f);
		//=====================================
		//"BONES"
		//=====================================
		for (int i = aLimit-1; i >0 ; i--) 
		{
			MakeNewCube(i,0);
			MakeNewCube(0,i);
			MakeNewCube(-i,0);
			MakeNewCube(0,-i);
			BonesCount = BonesCount+4; 

		}

		for (int i  = 1; i < aLimit-3; i++)
		{
			MakeNewCube(i,i);
			MakeNewCube(-i,i);
			MakeNewCube(i,-i);
			MakeNewCube(-i,-i);
			BonesCount = BonesCount+4; 
		}
		//=====================================
		//INNER CUBES
		//=====================================
		for (int i = 1; i<aLimit-3; i++) 
		{
			for (int j = 1; j < aLimit-i; j++) 
			{

				MakeNewCube_RandomY (i, i + j);
				MakeNewCube_RandomY (-i, i + j);
				MakeNewCube_RandomY (i, -i - j);
				MakeNewCube_RandomY (-i, -i - j);

				MakeNewCube_RandomY (-i-j, i);
				MakeNewCube_RandomY (i+j, i);
				MakeNewCube_RandomY (-i-j, -i);
				MakeNewCube_RandomY (i+j, -i);
			
			}
		}
	}
}
