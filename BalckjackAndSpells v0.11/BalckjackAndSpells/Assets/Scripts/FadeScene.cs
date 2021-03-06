﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour {
	
	
	public Texture2D fadeOutTexture;	
	public float fadeSpeed = 0.8f;	
	
	private int drawDepth = -1000;		
	private float alpha = 1.0f;			
	private int fadeDir = -1;			
	
	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;																
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);		
	}
	
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}
	
	void OnLevelWasLoaded()
	{
		BeginFade(-1);		
	}
	
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.tag == "Player") {
			Debug.Log("Hit");
			StartCoroutine (ChangeLevel ());
		}
	}
	
	IEnumerator ChangeLevel(){
		float fadeTime = BeginFade (1);	
		yield return new WaitForSeconds(fadeTime);
        int indexSC = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexSC + 1);
    }
}