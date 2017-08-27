using UnityEngine;
using System.Collections;

public class PhaseManager : MonoBehaviour {

    public int NumOfPhases = 1;
    private int CurrentPhase = 1;
    public bool TurnOffObjectsOnPhase3 = false;

    public GameObject[] PhaseOneGameObjects;
    public GameObject[] PhaseTwoGameObjects;
    public GameObject[] PhaseThreeGameObjects;

    // Use this for initialization
    void Start () {
        
        TurnOffGameObjects(PhaseTwoGameObjects);
        TurnOffGameObjects(PhaseThreeGameObjects);
        TurnOnGameObjects(PhaseOneGameObjects);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void NextPhase()
    {
        if (CurrentPhase < NumOfPhases)
        {
            CurrentPhase++;
            
        }
        if (CurrentPhase == 2)
        {
            TurnOffGameObjects(PhaseOneGameObjects);
            TurnOnGameObjects(PhaseTwoGameObjects);
        }
        if (CurrentPhase == 3)
        {
            if (TurnOffObjectsOnPhase3)
            {
                TurnOffGameObjects(PhaseThreeGameObjects);
            }
            else
            {
                TurnOffGameObjects(PhaseTwoGameObjects);
                TurnOnGameObjects(PhaseThreeGameObjects);
            }
        }
       
    }

    void TurnOnGameObjects(GameObject[] GameObjectArray)
    {
        for (int i = 0; i < GameObjectArray.Length; i++)
        {
            GameObjectArray[i].SetActive(true);
        }
    }

    void TurnOffGameObjects(GameObject[] GameObjectArray)
    {
        for (int i = 0; i < GameObjectArray.Length; i++)
        {
            GameObjectArray[i].SetActive(false);
        }
    }
}
