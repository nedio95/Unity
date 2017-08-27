/// <summary>
/// Directions sign.
/// 
/// How it is intended to work: 
/// The game object that this script is attached to is only a trigger collider to detect player interaction
/// On collision this object will activate and increase the scale of a UI canvas object, 
/// which as intended will be a semi-transparent background image with attached text containing instructions 
/// 
/// Requirements on gameObject: Box Collider 2D - trigger,This script
/// Requirements on popUpText: UI Canvas object, Child objects
/// 
/// Recommended setting: popUpTimeSek = 0.2
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DirectionsSign : MonoBehaviour {

	public GameObject popUpText;
	float popUpScale;
	bool hasCollided = false;
	public float PopUpTimeSek;

	void Start()
	{
		popUpScale = popUpText.transform.localScale.x;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		hasCollided = true;
	}

	void Update()
	{
		//Debug.Log (hasCollided);
		float scaMod = 0;
		if (hasCollided)
		{
			if (popUpScale < 1f)
			{
				scaMod = 1f / PopUpTimeSek;
			}
			popUpText.SetActive (true);
		}
		else if (!hasCollided && popUpScale > 0.1f)
			scaMod = -1f / PopUpTimeSek;
		else if(!hasCollided)
			popUpText.SetActive (false);

		if (popUpScale > 1f)
			popUpScale = 1f;
		
		if (!popUpText.activeInHierarchy)
			return;
		popUpScale += Time.deltaTime * scaMod;
		var sca = popUpText.transform.localScale;
		sca = new Vector3 (popUpScale, popUpScale, popUpScale);
		popUpText.transform.localScale = sca;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		hasCollided = false;
	}



}
