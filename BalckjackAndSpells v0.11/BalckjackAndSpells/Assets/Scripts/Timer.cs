using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    public Text TimerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimerText.text = " " + Math.Round(Time.timeSinceLevelLoad, 2);
    }
}
