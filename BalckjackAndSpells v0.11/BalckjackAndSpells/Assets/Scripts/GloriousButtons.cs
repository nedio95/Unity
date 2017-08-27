using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GloriousButtons : MonoBehaviour {


    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
        
    }
}
