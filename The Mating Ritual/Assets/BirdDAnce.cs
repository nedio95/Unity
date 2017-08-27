using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BirdDAnce : MonoBehaviour {

    enum GAMESTATE { STARTING, FEMALE, MALE, PLAYING, END };
    int GameState;

    public GameObject FEMALEBIRD;
    public GameObject MALEBIRD;

    public int[] Sequence;
    public int[] MaleSequence;
    int seqIndex;
    enum seqIndexes { LEFT = 1, RIGHT, UP, DOWN };
    bool press;

    int NumberOfMoves;
    int Level;
    int MaxLevel;
    int animIndex;

    public Sprite[] fBird;
    public Sprite[] mBird;

    public GameObject[] Lives;
    int Life;
    int maxLife;

    public Text FemaleProgress;
    public Text MaleProgress;

    public GameObject mGo;
    public GameObject fGo;

    public Text endText;
    public GameObject endText2;

    public AudioSource maleSong;
    public AudioSource femaleSong;
    public AudioSource maleSong2;
    public AudioSource femaleSong2;

    // Use this for initialization
    void Start () 
    {
        maxLife = 5;
        Life = 1;
        GameState = 1;
        Level = 1;
        MaxLevel = 5;
        NumberOfMoves = 3;
        press = false;
        seqIndex = 0;
        animIndex = 0;
        MaleProgress.text = "0/" + NumberOfMoves;
        FemaleProgress.text = "0/" + NumberOfMoves;
    }
	

	// Update is called once per frame
	void Update () 
    {

        for (int i = 0; i < maxLife; i++)
        {
            if (i < Life)
            {
                Lives[i].SetActive(true);
            }
            else
                Lives[i].SetActive(false);
        }

        if (GameState == (int)GAMESTATE.FEMALE)
        {
            fGo.SetActive(true);
            mGo.SetActive(false);
            Female();
        }
        else if (GameState == (int)GAMESTATE.MALE)
        {
            mGo.SetActive(true);
            fGo.SetActive(false);
            Male();
        }
        else
        {
            fGo.SetActive(false);
            mGo.SetActive(false);
        }

        if (GameState == (int)GAMESTATE.END)
        {
            if (Life == 0)
            {
                Application.LoadLevel("Sry");
            }
            else
            {
                Application.LoadLevel("Congratz");
            }
        }


    }


    void Female()
    {
        float x = Input.GetAxis("J1DpadHor");
        float y = Input.GetAxis("J1DpadVer");

      //  Debug.Log(x);
     //   Debug.Log(y);
        
        

        if (press == true && x == 0 && y == 0)
            press = false;

        if (press == false)
        {
            if (x != 0)
            {
                press = true;
                if (x < 0)
                    Sequence[seqIndex] = (int)seqIndexes.LEFT;
                else
                    Sequence[seqIndex] = (int)seqIndexes.RIGHT;
                seqIndex++;
                Debug.Log(Sequence[0] + " " + Sequence[1] + " " + Sequence[2] + " " + Sequence[3]);
            }
            else if (y != 0)
            {
                press = true;
                if (y < 0)
                    Sequence[seqIndex] = (int)seqIndexes.DOWN;
                else
                    Sequence[seqIndex] = (int)seqIndexes.UP;
                seqIndex++;
                Debug.Log(Sequence[0] + " " + Sequence[1] + " " + Sequence[2] + " " + Sequence[3]);
            }

        }

        FemaleProgress.text = seqIndex + "/" + NumberOfMoves;

        if (seqIndex == NumberOfMoves)
        {
            GameState = (int)GAMESTATE.PLAYING;
            if(NumberOfMoves < 5)
                femaleSong.Play();
            else
                femaleSong2.Play();
            StartCoroutine(playFemale());
        }
    }


    void Male()
    {
        bool temp = false;
        for (int i = 0; i < NumberOfMoves; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
                temp = true;
        }
        if (press == true && temp == false)
            press = false;

        if (press == false)
        {
            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                MaleSequence[seqIndex] = (int)seqIndexes.LEFT;
                press = true;
                seqIndex++;
                Debug.Log("Sqr");
                Debug.Log(MaleSequence[0] + " " + MaleSequence[1] + " " + MaleSequence[2] + " " + MaleSequence[3]);
            }
            else if (Input.GetKeyDown("joystick 1 button 2"))
            {
                MaleSequence[seqIndex] = (int)seqIndexes.RIGHT;
                press = true;
                seqIndex++;
                Debug.Log("Cir");
                Debug.Log(MaleSequence[0] + " " + MaleSequence[1] + " " + MaleSequence[2] + " " + MaleSequence[3]);
            }
            else if (Input.GetKeyDown("joystick 1 button 1"))
            {
                MaleSequence[seqIndex] = (int)seqIndexes.DOWN;
                press = true;
                seqIndex++;
                Debug.Log("X");
                Debug.Log(MaleSequence[0] + " " + MaleSequence[1] + " " + MaleSequence[2] + " " + MaleSequence[3]);
            }
            else if (Input.GetKeyDown("joystick 1 button 3")) 
            {
                MaleSequence[seqIndex] = (int)seqIndexes.UP;
                press = true;
                seqIndex++;
                Debug.Log("Tri");
                Debug.Log(MaleSequence[0] + " " + MaleSequence[1] + " " + MaleSequence[2] + " " + MaleSequence[3]);
            }
        }

        MaleProgress.text = seqIndex + "/" + NumberOfMoves;

        if (seqIndex == NumberOfMoves)
        {
            GameState = (int)GAMESTATE.PLAYING;
            if (NumberOfMoves < 5)
                maleSong.Play();
            else
                maleSong2.Play();
            StartCoroutine(playMale());
        }
        
    }

    IEnumerator playFemale()
    {
        yield return new WaitForSeconds(0.5f);
    //    FEMALEBIRD.GetComponent<SpriteRenderer>().sprite = fBird[0];
        FEMALEBIRD.GetComponent<Image>().sprite = fBird[0];
        yield return new WaitForSeconds(0.75f);
        if (animIndex != NumberOfMoves)
        {
            //FEMALEBIRD.GetComponent<SpriteRenderer>().sprite = fBird[Sequence[animIndex]];
            FEMALEBIRD.GetComponent<Image>().sprite = fBird[Sequence[animIndex]];
            animIndex++;
            StartCoroutine(playFemale());
        }
        else
        {
            FEMALEBIRD.GetComponent<Image>().sprite = fBird[0];
            seqIndex = 0;
            animIndex = 0;
            GameState = (int)GAMESTATE.MALE;
        }
            
    }

    IEnumerator playMale()
    {
        yield return new WaitForSeconds(0.5f);
        MALEBIRD.GetComponent<Image>().sprite = mBird[0];
        yield return new WaitForSeconds(1f);

        if (animIndex != NumberOfMoves)
        {
            MALEBIRD.GetComponent<Image>().sprite = mBird[MaleSequence[animIndex]];
            animIndex++;
            StartCoroutine(playMale());
        }
        else
        {
            bool check = true;
            for (int i = 0; i < NumberOfMoves; i++)
            {
                if (Sequence[i] != MaleSequence[i])
                    check = false;
            }

            if (Level != MaxLevel)
            {
                Level++;
                NumberOfMoves++;
                MaleProgress.text = "0/" + NumberOfMoves;
                FemaleProgress.text = "0/" + NumberOfMoves;
            }
            MALEBIRD.GetComponent<Image>().sprite = mBird[0];
            seqIndex = 0;
            animIndex = 0;
            press = false;

            if (check)
            {
                Life += 1;
                if (Life == MaxLevel)
                {
                    GameState = (int)GAMESTATE.END;
                    Debug.Log("GG");
                }
                else
                {
                    GameState = (int)GAMESTATE.FEMALE;
                }
            }
            else 
            {
                Life -= 1;
                if (Life == 0)
                {
                    GameState = (int)GAMESTATE.END;
                    Debug.Log("BG");
                }
                else
                {
                    GameState = (int)GAMESTATE.FEMALE;
                }
            }
        }
    }
}


