using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerController : MonoBehaviour
{


    // when player selected one object;
    bool m_IsMouseDragging;
    //offset between camera and currentgame object distance
    Vector3 offsetValue;
    //to convert world to screen point.
    Vector3 positionOfScreen;
    //keeping "y" at same value for  staying on platform.
    private float m_offsetY = 1F;
    public float MinDistanceToLand = 3F;

    // Use this for initialization





    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            m_IsMouseDragging = true;
            positionOfScreen = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            offsetValue = this.gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            m_IsMouseDragging = false;
        }
        //Is mouse Moving
        if (m_IsMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);

            //  currentPosition.y = m_offsetY;
            //It will update target gameobject's current postion.
            this.gameObject.transform.position = currentPosition;
        }
    }






}
