using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

	public int rotationOffset = 0;
	public bool rotate = false;
	private float timeToFire = 0;
    public float fireRate = 1;
	Transform firePoint;
	public GameObject Arrow;
	private GameObject Player01;

	void Awake () {
		
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("FirePoint NOT found!");
		}
		Player01 = GameObject.FindWithTag ("Player");
	}
		
	// Update is called once per frame
	void Update () {
	
		if (rotate) {
			Vector3 difference = Player01.transform.position - gameObject.transform.position;
			difference.Normalize ();
			float rotaZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
			float rot = rotaZ + rotationOffset;

			gameObject.transform.rotation = Quaternion.Euler (0f, 0f, rot);
		}

		if (Time.time > timeToFire) {
			timeToFire =Time.time + 1/ fireRate;
			Shoot();
		}
	}

	void Shoot() {

		Vector3 firePointPosition = new Vector3 (firePoint.position.x, firePoint.position.y,0);
		
		GameObject obj = Instantiate(Arrow, firePointPosition, firePoint.rotation)as GameObject;
		
		
	}


}
