using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int gameState = 0;

	public GameObject[] Robot;
	public GameObject victoryUI;
	public Text VictoryText; 
	public GameObject startCanv;
	bool gameStarted = false;

	// Use this for initialization
	void Start () 
	{
		gameState = 0;
		for (int i = 0; i < 2; i++) 
		{
			Robot [i].transform.LookAt 
			(new Vector3 
				(
				Robot [i].transform.position.x * -1f,
				Robot [i].transform.position.y,
				Robot [i].transform.position.z * -1f
				)
			);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameStarted)
			return;
		//Debug.Log(LevelManager.gettingInPlace);
		if ((LevelManager.gettingInPlace == false) & (gameState > 1))
		{
		//	Debug.Log ("This is ran");
			gameState = 4;
			startCanv.SetActive (true);
			gameStarted = true;
		}
	//	Debug.Log (gameState);
	}

	public void GameLostBy(int playerLostIndex)
	{
		string winningPlayer;
		if (playerLostIndex == 2)
		{
			winningPlayer = "Victory: Player 1"; 
		}
		else
		{
			LowerBody R2script = Robot[1].GetComponent<LowerBody> (); 
			if(R2script.isPlayer == true)
				winningPlayer = "Victory: Player 2"; 
			else
				winningPlayer = "Victory: Bada Zz Rob Od"; 
		}
		VictoryText.text = winningPlayer;
		victoryUI.SetActive (true);
		Time.timeScale = 0f;
	}


}
