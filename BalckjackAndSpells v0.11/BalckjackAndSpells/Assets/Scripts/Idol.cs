using UnityEngine;
using System.Collections;

public class Idol : MonoBehaviour {

    public GameObject idol;
    public GameObject boulder;

    public void ActivateIdol()
    {
        idol.SetActive(true);
        boulder.SetActive(false);
    }
}
