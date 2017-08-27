using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown("joystick 1 button 1"))
            Application.LoadLevel("dance");
        if (Input.GetKeyDown("joystick 1 button 2"))
            Application.Quit();
    }
}
