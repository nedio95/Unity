using UnityEngine;
using System.Collections;

public class SheepCollection : MonoBehaviour
{

    public bool thisIsSheep;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (thisIsSheep)
        {
            SheepManager.sheepCollected = true;
            Destroy(gameObject);
        }
        else if (SheepManager.sheepCollected)
            SheepManager.sheepSacrificed = true;
    }
}
