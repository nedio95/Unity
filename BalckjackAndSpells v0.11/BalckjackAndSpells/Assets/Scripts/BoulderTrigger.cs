using UnityEngine;
using System.Collections;

public class BoulderTrigger : MonoBehaviour {

    public float Gravity;
    public GameObject Boulder;


    void OnTriggerEnter2D(Collider2D col)
    {
        Boulder.GetComponent<Rigidbody2D>().gravityScale = Gravity;


    }
}
