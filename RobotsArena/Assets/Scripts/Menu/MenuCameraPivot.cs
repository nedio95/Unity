using UnityEngine;
using System.Collections;

public class MenuCameraPivot : MonoBehaviour {

	float rotSpeed = 15;

	void Update () 
	{
		gameObject.transform.Rotate (Vector3.up * rotSpeed * Time.deltaTime);
	}
}
