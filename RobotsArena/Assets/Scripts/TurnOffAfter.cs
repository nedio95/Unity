using UnityEngine;
using System.Collections;

public class TurnOffAfter : MonoBehaviour {

	public float sek;

	void Update () 
	{
		sek -= Time.deltaTime;
		if (sek < 0)
			gameObject.SetActive (false);
	}
}
