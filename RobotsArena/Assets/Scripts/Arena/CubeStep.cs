using UnityEngine;
using System.Collections;

public class CubeStep : MonoBehaviour {

	public GameObject parent;
	Cube otherThing;

	void Start()
	{
		otherThing = parent.GetComponent<Cube>();
	}
		
	void OnTriggerEnter(Collider col)
	{
		//	Debug.Log("Trigger Reg");
		otherThing.steppedOn = true;
	}
	void OnTriggerExit(Collider col)
	{
		//	Debug.Log("Trigger Exit");
		otherThing.steppedOn = false;
	}
}
