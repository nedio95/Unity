using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public GameObject exit;

    void OnTriggerEnter2D(Collider2D col)
    {
        exit.GetComponent<GoalManagerLvl0>().GetKey();
        Destroy(gameObject);
    }
}
