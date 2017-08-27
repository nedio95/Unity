using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaleBird : MonoBehaviour {

    static float speed = 5.0f;
    static float turnSpeed = 25.0f;

    public GameObject femaleBird;
    public Text distanceText;
    public GameObject distanceBar;
    public GameObject wtf;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //====
        //Calculate distance
        //====

        int distance = (int)(Vector3.Distance(gameObject.transform.position, femaleBird.transform.position) * 100);
        distanceText.text = distance.ToString();

        var transDistBar = distanceBar.transform.position;
        transDistBar.y = (distance - 1000) / 10;
        Debug.Log(transDistBar.y);
       // distanceBar.transform.position = transDistBar;

        //====
        //Movement
        //====

        //Setup variables for the raycasting
        float totalSpeed = 0f;
        int layerMask = 1 << 11;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Raycasting to see if there is a object in front
        if (Physics.Raycast(transform.position, fwd, 40, layerMask))
        {
            
            Debug.Log("Birdie Found");
            totalSpeed = speed * 1.1f;
        }
        else
        {
            totalSpeed = speed * 0.9f;
        }

        //he movement itself
        transform.Translate(Vector3.forward * Time.deltaTime * totalSpeed); 

        //====
        // LEFT THUMBSTICK
        //====

        //Get Input
        float x = Input.GetAxis("J1Hor");
        float y = Input.GetAxis("J1Ver");

      
        //====
        //Rotation
        //===

        //Calculate angles
        x = x * Time.deltaTime * turnSpeed;
        y = y * Time.deltaTime * turnSpeed;

        //Rotation itself
        transform.Rotate(Vector3.up * x);
        transform.Rotate(Vector3.right * y);
    }

   
}
