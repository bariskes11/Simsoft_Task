using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlSystem : MonoBehaviour
{
    
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;




    // Use this for initialization
    void Start()
    {

    }

    RaycastHit hitInfo;
    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            getTarget = ClickedGameObject(out hitInfo);
            if (getTarget != null)
            {
                isMouseDragging = true;
                positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }
        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            currentPosition.y = 1;
            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }


    }
    Ray ray;
    GameObject ClickedGameObject(out RaycastHit hit)
    {
        GameObject target = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int Layer = LayerMask.NameToLayer("Items");
        Debug.Log(Layer);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit, 1<< Layer)) // only Items Layer
        {
            
            target = hit.collider.gameObject;
            Debug.Log(target.name);
        }
        return target;
    }


}
