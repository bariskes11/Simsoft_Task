using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatus : MonoBehaviour
{

    [Tooltip("Which Gameobject is suitable for this box")]
    public GameObject RequiredObject;
    [Tooltip("Particle for Succesful Box Complete")]
    public ParticleSystem SuccesFX;
    // sets the object type to collect Red Green Or Blue
    public string CorrectObjectName;
    public List<GameObject> m_AddedObjects = new List<GameObject>();
    //get if this box is completed
    public bool CompletedThisBox;
    private void Start()
    {
        // sets current added objects on this box
        CompletedThisBox = false;
        var rslt = this.GetComponentsInChildren<Item>();
        if (rslt.Length > 0)
        {
            foreach (var item in rslt)
            {
                m_AddedObjects.Add(item.gameObject);
            }
        }
    }
    //Stops Item To move
    private void stopItem()
    {
        StartCoroutine(waitTimeOutAndStopMoving());

    }
    IEnumerator waitTimeOutAndStopMoving()
    {
        yield return new WaitForSeconds(1F);
        var childs = this.GetComponentsInChildren<Item>(); // current Items
        foreach (var item in childs)
        {
            item.completedMovement = true;

        }
    }
    private void CheckIfRowCollected()
    {
        bool boxCompleted = true;
        if (m_AddedObjects.Count != 4) // all boxes must have  4 Item
            return;
        foreach (var item in m_AddedObjects)
        {
            if (item.name != CorrectObjectName) // all items name must be  correct to check this box is completed.
            {
                boxCompleted = false;
                return;
            }
        }

        if (boxCompleted)
        {
            CompletedThisBox = true;
            stopItem();
            SuccesFX.Play(); // simple particle to give feedback about complete status

        }

    }

    public void AddObject(GameObject gmObj)
    {
        if (string.IsNullOrEmpty(CorrectObjectName) && m_AddedObjects.Count >= 4) // this box is not for collection
            return;
        m_AddedObjects.Add(gmObj);
        CheckIfRowCollected();
    }
    public void RemoveObject(GameObject gm)
    {

        if (m_AddedObjects.Count > 0)
            m_AddedObjects.Remove(gm);
    }




}
