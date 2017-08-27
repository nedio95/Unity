using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject Buttons;
    public GameObject Platform;
 
    bool Status = false;
    static int ButtonPresses = 0;
  
   
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("buttonpress");
      
        if (Status == false)
        {
            var pos = Buttons.transform.position;
            pos.y -= 0.1f;
            Buttons.transform.position = pos;
            ButtonPresses++;
            if (ButtonPresses == 2)
            {
                Platform.SetActive(true);
            }
        }
        Status = true;
      
    }

 
}
