using UnityEngine;
using System.Collections;

public class MeterBar : MonoBehaviour {

    public KeyCode changeWorld;
    bool whichWorld = false; // 0 = druid, 1 = necromancer;

    public GameObject BarSlider_Left;
    public GameObject BarSlider_Right;
    float BarPos_min;
    float BarPos_max;


    

	// Use this for initialization
	void Start ()
    {
        var startPos_L = BarSlider_Left.transform.position;
        var startPos_R = BarSlider_Right.transform.position;

        BarPos_min = startPos_R.x;
        BarPos_max = startPos_L.x;


        /*
        var pos = BarSlider_Left.transform.position;
        pos.x = BarPos_min_left;
        BarSlider_Left.transform.position = pos;
        var pos2 = BarSlider_Right.transform.position;
        pos2.x = BarPos_min_right;*/
      //  BarSlider_Right.transform.position = pos2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(changeWorld))
        {
            if (whichWorld == true)
                whichWorld = false;
            else
                whichWorld = true;
        }
      //  Debug.Log(BarPos_max_left + " " + BarPos_min_left);
        //   Debug.Log(whichWorld);
        MoveMeters();
    }

    public void MoveMeters()
    {
        float barModifier;
        if (whichWorld)
        {
            barModifier = -1f;

            var pos = BarSlider_Left.transform.position;
            if (pos.x >= BarPos_min)
            {
                pos.x += barModifier * Time.deltaTime;
                BarSlider_Left.transform.position = pos;
            }
            else
            {
               // Debug.Log("GAME OVER");
            }

            pos = BarSlider_Right.transform.position;
            if (pos.x >= BarPos_min) pos.x += barModifier * Time.deltaTime;
            BarSlider_Right.transform.position = pos;
            //  Debug.Log("MinL" + BarPos_min_left + " posX" + pos.x);
        }
        else
        {
            barModifier = 1f;

            var pos = BarSlider_Right.transform.position;
            if (pos.x <= BarPos_max)
            {
                pos.x += barModifier * Time.deltaTime;
                BarSlider_Right.transform.position = pos;
            }
            else
            {
                //Debug.Log("GAME OVER");
            }
            pos = BarSlider_Left.transform.position;
            if (pos.x <= BarPos_max) pos.x += barModifier * Time.deltaTime;
            BarSlider_Left.transform.position = pos;

        }
        /*
        var pos = BarSlider_Left.transform.position;
        if (pos.x <= BarPos_max_left && pos.x >= BarPos_min_left)
        {
            pos.x += barModifier * Time.deltaTime;
            
        }
        BarSlider_Left.transform.position = pos ;
        */
    }
}
