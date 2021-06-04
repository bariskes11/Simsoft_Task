using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlSystem : MonoBehaviour
{
    [Tooltip("Shows Current Selected GameObject")]
    public GameObject SelectedGameObject;
    // when player selected one object;
    bool m_IsMouseDragging;
    //offset between camera and currentgame object distance
    Vector3 offsetValue;
    //to convert world to screen point.
    Vector3 positionOfScreen;
    //keeping "y" at same value for  staying on platform.
    private float offsetY = 1F;

    [Tooltip("Shows Possible Placement Points")]
    public GameObject[] PossibleLandingPoints;
    [Tooltip("To Indicate Landing Points with different Color")] 
    public Material LandingPointInticatorColor;
    [Tooltip("Normal Landing Place PointColor")]
    public Material LandingPointNormalColor;

    // Use this for initialization
    void Start()
    {
        PossibleLandingPoints = GameObject.FindGameObjectsWithTag(Enums.TagNames.LandingPoint.ToString());
        foreach (var item in PossibleLandingPoints)
        {
            item.GetComponent<MeshRenderer>().material = LandingPointNormalColor;
        }
    }

    RaycastHit hitInfo;
    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            SelectedGameObject = ClickedGameObject(out hitInfo);
            if (SelectedGameObject != null)
            {
                m_IsMouseDragging = true;
                positionOfScreen = Camera.main.WorldToScreenPoint(SelectedGameObject.transform.position);
                offsetValue = SelectedGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
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

            currentPosition.y = offsetY;
            //It will update target gameobject's current postion.
            SelectedGameObject.transform.position = currentPosition;
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
