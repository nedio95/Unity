using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	bool dPadDown = false;
	public GameObject[] selectors;
	int activeSelector = 0;

	public GameObject robot2;
	public GameObject[] cameras;
	public GameObject HUD_UI;
	public Text player2;
	public GameObject AImanagerment;

	void Update () 
	{
		if (Input.GetKeyDown ("joystick 1 button 1")) 
		{
			Debug.Log("Selected");
			if(activeSelector == 2)
				Application.Quit();
			else if(activeSelector == 0)
			{
				// VsPlayer
				GameManager.gameState = 2;
				gameObject.SetActive (false);
				cameras [0].SetActive (false);
				cameras [2].SetActive (true);
				cameras [3].SetActive (true);
				HUD_UI.SetActive(true);

			}
			else if(activeSelector == 1)
			{
				//VsAI
				GameManager.gameState = 3;
				gameObject.SetActive (false);
				cameras [0].SetActive (false);
				cameras [1].SetActive (true);
				LowerBody scriptR2 = robot2.GetComponent<LowerBody> ();
				scriptR2.isPlayer = false;
				HUD_UI.SetActive(true);
				player2.text = "Bada Zz Rob Od";
				AImanagerment.SetActive (true);
			}
		}

		if (Input.GetAxis ("J1DpadVer") != 0) 
		{ 
			if(dPadDown == false)
			{
				dPadDown = true;
				if(Input.GetAxis ("J1DpadVer") == 1)
				{
					SelectorUp();
				}
				if(Input.GetAxis ("J1DpadVer") == -1)
				{
					SelectorDown();
				}
			}
		}
		else
		{
			dPadDown = false;
		}
	}

	void SelectorUp()
	{
		selectors [activeSelector].SetActive (false);
		if (activeSelector == 0)
			activeSelector = 2;
		else
			activeSelector -= 1;
		selectors [activeSelector].SetActive (true);
	}

	void SelectorDown()
	{
		selectors [activeSelector].SetActive (false);
		if (activeSelector == 2)
			activeSelector = 0;
		else
			activeSelector += 1;
		selectors [activeSelector].SetActive (true);
	}

}
