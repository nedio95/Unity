using UnityEngine;
using System.Collections;

public class OuterCube : MonoBehaviour {

	float speed;
	public Behaviour thisScript;
	
	Vector3 StartPosition;
	
	void Start () {
		gameObject.SetActive (false);
		StartPosition = transform.position;
		speed = 2.5f;
	}
	
	void Update () { 
		Vector3 TargetPos = new Vector3 (StartPosition.x, 1, StartPosition.z);
		
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, TargetPos, step);
		if(transform.position == TargetPos)
		{
			thisScript.enabled = false;
		}
	}
}
