using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GoalManagerLvl0 : MonoBehaviour
{
    bool gameFinished = false;
    public int KeysToCollect;
    float time = 0f;

    GameObject Player1;
    GameObject Player2;

    bool player1In = false;
    bool player2In = false;

    public GameObject LevelOverScreen;
    public GameObject OpenDoor;
    public Text txt;


	// Use this for initialization
	void Start ()
    {
        Player1 = GameObject.Find("Player1_Necro");
        Player2 = GameObject.Find("Player2_Druid");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!gameFinished)
        {
            time += Time.deltaTime;
        }
        if (KeysToCollect <= 0)
        {
            OpenDoor.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (KeysToCollect > 0) return;

        if (gameFinished) return;
        GameObject obj = col.gameObject;
        if (obj == Player1)
        {
            player1In = true;

        }
        else if (obj == Player2)
        {
            player2In = true;
        }
        else return;
        obj.SetActive(false);

        if (player1In && player2In)
        {
            gameFinished = true;
            LevelOverScreen.SetActive(true);
            txt.text = "Congratualtions! \nYour time is: " + Math.Round(time, 2) + " Sec";
        }         
    }

    public void ChangeToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void GetKey()
    {
        KeysToCollect -= 1;
        
    }
}
