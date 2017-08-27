using UnityEngine;
using System.Collections;

public class SwingMove : MonoBehaviour {

    public GameObject Platform;
    public float speed;
    public float AngleRange;
    int direction = 1;
    float startAngle;

    void Start() {

        startAngle = gameObject.transform.eulerAngles.z;
        Debug.Log(startAngle);
    }


    // Update is called once per frame
    void Update()
    {

        float currentAngel = gameObject.transform.eulerAngles.z;

        // Debug.Log(startAngle + AngleRange);
        if (currentAngel < 180)
        {
            if ((startAngle + AngleRange) <= currentAngel)
            {
                //   Debug.Log("cur::" + gameObject.transform.eulerAngles.z + "bound::" + startAngle + AngleRange);
                direction = -1;
            }
        }
     // Debug.Log("cur::" + gameObject.transform.eulerAngles.z + "bound::" + (startAngle - AngleRange));

        if (currentAngel > 180)
        {
            if ((360 - AngleRange) >= currentAngel)
            {
              //Debug.Log("cur::" + gameObject.transform.eulerAngles.z + "bound::" + (startAngle + AngleRange));
              //Debug.Log("under");
                direction = 1;
            }
        }

        gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * direction * speed),Space.Self);

        Platform.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * direction * speed), Space.Self);
    }

}
