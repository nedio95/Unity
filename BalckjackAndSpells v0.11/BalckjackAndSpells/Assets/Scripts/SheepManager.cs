using UnityEngine;
using System.Collections;

public class SheepManager : MonoBehaviour {

    public static bool sheepCollected = false;
    public static bool sheepSacrificed = false;

    float StartY;
    float DeltaY;

    public float Speed;
    public GameObject Door;

    // Use this for initialization
    void Start () {
        StartY = Door.transform.position.y;
        DeltaY = StartY + 1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (sheepSacrificed)
        {
            var doorPos = Door.transform.position;
            doorPos.y += Time.deltaTime * Speed;
            Door.transform.position = doorPos;

            if (doorPos.y > DeltaY) Destroy(gameObject);
        }
    }
}
