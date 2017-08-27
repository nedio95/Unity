using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {

	//public bool isCloud = true;
    private bool moveUp = true;
    private bool moveUp02 = false;
    public GameObject Waypoints;
    private Transform Waypoint01;
    private Transform Waypoint02;
	public float moveSpeed = 1;
    private float timeCount;
    public float timeCountMax = 1f;


	// Use this for initialization
	 void Start () {
       
		Waypoint01 = Waypoints.transform.FindChild ("WayPoint01");
		Waypoint02 = Waypoints.transform.FindChild ("WayPoint02");
        if(Waypoint01 == null || Waypoint02 == null)
        {
            Debug.Log("Everybody's dead dave");
        }
        timeCount = timeCountMax/2;
    }
	
	// Update is called once per frame
	void Update () {
	
		if (timeCount > 0) {
			timeCount -= Time.deltaTime;
		} else {
			timeCount = 0;
		}
		if (moveUp) {
			Vector3 dir = Waypoint01.position - transform.position;
			dir.z = 0.0f;
			transform.position += (dir).normalized * moveSpeed * Time.deltaTime;
			if (timeCount == 0) {
				moveUp = false;
				timeCount = timeCountMax;
			}
		}
		if (!moveUp) {

			Vector3 dir = Waypoint02.position - transform.position;
			dir.z = 0.0f;
			transform.position += (dir).normalized * moveSpeed * Time.deltaTime;
			if (timeCount == 0) {
				moveUp = true;
				timeCount = timeCountMax;
			}
		}
	}
}
		 
	
	



