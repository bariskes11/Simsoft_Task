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
        Debug.Log("Entered Trigger:" + other.gameObject.name);
        if (other.gameObject.tag == Enums.TagNames.Items.ToString() && this.GetComponentInChildren<Item>() == null) // is this an Item and this point has no Item
        {

            currentBox.AddObject(other.gameObject);
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.Translate(new Vector3(0, 1, 0));
        }

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaved Trigger:" + other.gameObject.name);
        if (other.gameObject.tag == Enums.TagNames.Items.ToString()) // is this an Item
        {
            currentBox.RemoveObject(other.gameObject);
            other.gameObject.transform.SetParent(null);


        }
    }
}
