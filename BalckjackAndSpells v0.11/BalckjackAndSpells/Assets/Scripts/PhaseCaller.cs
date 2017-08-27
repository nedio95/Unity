using UnityEngine;
using System.Collections;

public class PhaseCaller : MonoBehaviour {

    public bool IsKey = false;
    private GameObject GameManagerRef;

    private void Start()
    {
        GameManagerRef = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManagerRef.GetComponent<PhaseManager>().NextPhase();

        if (IsKey)
        {
            Destroy(this.gameObject);
        }
    }
}
