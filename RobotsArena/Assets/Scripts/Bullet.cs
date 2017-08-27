using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float BulletSpeed = 20f;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = transform.forward*BulletSpeed;
	}

	void OnCollisionEnter (Collision col) 
	{
			Destroy (gameObject);
	}
}