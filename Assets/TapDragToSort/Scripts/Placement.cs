using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public bool HasObject;
    public GameObject currentGameObject;
    [Tooltip("To Indicate Landing Points with different Color")]
    public Material LandingPointInticatorColor;
    [Tooltip("Normal Landing Place PointColor")]
    public Material LandingPointNormalColor;
    private BoxStatus currentBox;
    private void Start()
    {
        //gets current box
        currentBox = this.GetComponentInParent<BoxStatus>();
   

    }
    // if user gets close to this place adds the current object  to object list
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<Item>() != null) // is this an Item
        {
            
                currentBox.AddObject(other.gameObject);
        }

    }

    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaved Trigger:"+other.gameObject.name);
        if (other.GetComponent<Item>() != null ) // is this an Item
        {
            currentBox.RemoveObject(other.gameObject);
           
        }
    }
}
