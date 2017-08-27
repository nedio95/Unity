using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	void Start () {
		StartCoroutine (Waiting());
	}
	
		IEnumerator Waiting(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (1);
}
}
