using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour {

	public void ExitButtonPressed()
	{
		SceneManager.LoadScene(1);
	}

}
