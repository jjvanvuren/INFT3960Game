using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source
// https://www.youtube.com/watch?v=dV4bNUXR2dE

public class Background : MonoBehaviour
{
    public Transform background1;
    public Transform background2;
    public Transform cam;

    private bool whichOne = true;
    private float currentPosition = 40;


    // Update is called once per frame
    void Update()
    {
        
        if (currentPosition < cam.position.x)
        {
            if (whichOne)
            {
                background1.localPosition = new Vector3(background1.localPosition.x + 80, 0, 10);
            }
            else
            {
                background2.localPosition = new Vector3(background2.localPosition.x + 80, 0, 10);
            }
            currentPosition += 40;

            whichOne = !whichOne;
        }
        if (currentPosition > cam.position.x + 40)
        {
            if (whichOne)
            {
                background2.localPosition = new Vector3(background2.localPosition.x - 80, 0, 10);
            }
            else
            {
                background1.localPosition = new Vector3(background1.localPosition.x - 80, 0, 10);
            }
            currentPosition -= 40;

            whichOne = !whichOne;
        }
    }
}
