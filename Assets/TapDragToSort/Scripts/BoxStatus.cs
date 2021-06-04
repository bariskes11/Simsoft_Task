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
    public bool CompletedThisBox;
    private void Start()
    {

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


    private void CheckIfRowCollected()
    {
        bool boxCompleted = true;
        if (m_AddedObjects.Count != 4)
            return;
        foreach (var item in m_AddedObjects)
        {
            if (item.name != CorrectObjectName)
            {
                boxCompleted = false;
                return;
            }
        }

        if (boxCompleted)
        {
            CompletedThisBox = true;
            SuccesFX.Play();


            Debug.Log("Box Completed");
        }

    }

    public void AddObject(GameObject gmObj)
    {
        if (string.IsNullOrEmpty(CorrectObjectName) && m_AddedObjects.Count>=4) // this box is not for collection
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
