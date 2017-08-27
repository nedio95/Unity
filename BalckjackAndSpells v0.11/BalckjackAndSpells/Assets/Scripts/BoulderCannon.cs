using UnityEngine;
using System.Collections;

public class BoulderCannon : MonoBehaviour {

    public float rotTime = 2f;
    public float stayTime = 2f;
    
    public GameObject[] firePoint;
    public GameObject Arrow;

    float rotSpeed = 0f;
    float count = 1f;
    bool move = false;


    // Use this for initialization
    void Start ()
    {
        rotSpeed = 45f / rotTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        count -= Time.deltaTime;
        if (move)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotSpeed));
            
        }
        
        if (count < 0f)
        {   
            
            if (move == true)
            {
                count = stayTime;
                move = false;
                Shoot();
            }
            else
            {
                count = rotTime;
                //Shoot();
                move = true;
            }
        }
	}

    void Shoot()
    {
        int fpcount = firePoint.GetLength(0) - 1;
        do
        {
            Transform fp = firePoint[fpcount].transform;
            Vector3 firePointPosition = new Vector3(fp.transform.position.x, fp.position.y, 0);

            GameObject obj = Instantiate(Arrow, firePointPosition, fp.rotation) as GameObject;
            fpcount--;
        } while (fpcount >= 0);
    }

}
