using UnityEngine;
using System.Collections;

public class DoorWButton : MonoBehaviour {

    public GameObject Door;
    public GameObject Button;
    float StartY;
    float DeltaY;
    

    bool Status = false;
    public float Speed;
	// Use this for initialization
	void Start ()
    {
        StartY = Door.transform.position.y;
        DeltaY = StartY + 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Status)
        {
            var doorPos = Door.transform.position;
            doorPos.y += Time.deltaTime * Speed;
            Door.transform.position = doorPos;

            if (doorPos.y > DeltaY) Destroy(gameObject);
        } 
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("buttonpress");
        if (Status == false)
        {
            var pos = Button.transform.position;
            pos.y -= 0.1f;
            Button.transform.position = pos;
        }
        Status = true;
        
    }

}
