using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

    private int CurrentWorld = 0; // 0 neutral, 1 necro, 2 druid

    public GameObject[] NeutralObjects;
    public GameObject[] DruidObjects;
    public GameObject[] NecroObjects;

	// Use this for initialization
	void Start () {
        TurnOffGameObjects(NecroObjects);
        TurnOffGameObjects(DruidObjects);
        TurnOnGameObjects(NeutralObjects);
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextWorld();
        }
	}

    void NextWorld()
    {
        switch (CurrentWorld)
        {
            case 0:
                CurrentWorld = 1;
                TurnOffGameObjects(NeutralObjects);
                TurnOffGameObjects(DruidObjects);
                TurnOnGameObjects(NecroObjects);
                break;
            case 1:
                CurrentWorld = 2;
                TurnOffGameObjects(NeutralObjects);
                TurnOffGameObjects(NecroObjects);
                TurnOnGameObjects(DruidObjects);
                
                break;
            case 2:
                CurrentWorld = 1;
                TurnOffGameObjects(NeutralObjects);
                TurnOffGameObjects(DruidObjects);
                TurnOnGameObjects(NecroObjects);
                break;
            default:
                break;
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
