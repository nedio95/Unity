using UnityEngine;
using System.Collections;

public class AxeRotate : MonoBehaviour {


    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0f, 0f, speed)*Time.deltaTime);
	}
}
