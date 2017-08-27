using UnityEngine;
using System.Collections;

public class AICollisions : MonoBehaviour {

	public GameObject managerAI; 
	public int Index;

	enum DIRECTIONS
	{
		Zp = 0,
		Zm = 1,
		Xp = 2,
		Xm = 3
	};

	void OnTriggerEnter(Collider col)
	{
		AIManager manager = managerAI.GetComponent<AIManager> ();
		manager.DirectionUnavailable (Index);

	}

	void OnTriggerStay(Collider col)
	{
		AIManager manager = managerAI.GetComponent<AIManager> ();
		manager.DirectionUnavailable (Index);

	}

	void OnTriggerExit(Collider col)
	{
		AIManager manager = managerAI.GetComponent<AIManager> ();
		manager.DirectionAvailable (Index);

	}
}
