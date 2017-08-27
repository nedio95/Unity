using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {



    //public void MenuPress(int LevelIndex)
    //{
    //    SceneManager.LoadScene(LevelIndex);
    //}

    //public void ExitGame()
    //{


    //    Application.Quit();

    //}
    bool dPadDown = false;
    public GameObject[] selectors;
    int activeSelector = 0;
    public int numSelectors;
    public int[] LevelIndex;
    public bool hasQuit;

    void Update()
    {
        if (Input.GetKeyDown("joystick 1 button 0"))
        {

            for (int index = 0; index < numSelectors; index++)
            {
                if (activeSelector == index)
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(LevelIndex[index]);
                    return;
                }
            }
            if (activeSelector == numSelectors)
                Application.Quit();
        }

        if (Input.GetAxis("J1DpadVer") != 0)
        {
            if (dPadDown == false)
            {
                dPadDown = true;
                if (Input.GetAxis("J1DpadVer") == 1)
                {
                    SelectorUp();
                }
                if (Input.GetAxis("J1DpadVer") == -1)
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
        selectors[activeSelector].SetActive(false);
        if (activeSelector == 0)
            if (hasQuit)
                activeSelector = numSelectors-1;
            else
                activeSelector = numSelectors-1;
        else
            activeSelector -= 1;
        selectors[activeSelector].SetActive(true);
    }

    void SelectorDown()
    {
        selectors[activeSelector].SetActive(false);
        if (hasQuit)
        {
            if (activeSelector == numSelectors-1)
                activeSelector = 0;
            else
                activeSelector += 1;
        }
        else
        {
            if (activeSelector == numSelectors-1)
                activeSelector = 0;
            else
                activeSelector += 1;
        }
        selectors[activeSelector].SetActive(true);
    }

}
