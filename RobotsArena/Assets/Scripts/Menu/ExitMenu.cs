using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("joystick 1 button 1"))
		{
			Time.timeScale = 1;
			//SceneManager.LoadScene ("Level", LoadSceneMode.Single);
			Application.LoadLevel("Level");
		}
		else
		if (Input.GetKey ("joystick 1 button 2"))
			Application.Quit ();
	}
}
