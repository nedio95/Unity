using UnityEngine;
using System.Collections;

public class MenuSelector : MonoBehaviour {

	static float rotSpeed = 180f;

	void Update () 
	{
		gameObject.transform.Rotate (Vector3.right * Time.deltaTime * rotSpeed);
	}
}
