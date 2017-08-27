using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

	public int moveSpeed = 230;
    public float DestroyTime = 1f;
	//Vector3 shootingDirection;
	// Update is called once per frame

    void Start()
    {
        Destroy(this.gameObject, DestroyTime);
    }

	void Update () {
	

		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject, 0);
	}

	//public void getAngle(Vector3 a) {
	//	shootingDirection = a;
	//}
}
