using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatus : MonoBehaviour
{

    [Tooltip("Which Gameobject is suitable for this box")]
    public GameObject RequiredObject;
    public string CorrectObjectName;
    public List<GameObject> m_AddedObjects = new List<GameObject>();
    public bool CompletedThisBox;
    private void Start()
    {
        CompletedThisBox = false;
           var rslt= this.GetComponentsInChildren<Item>();
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
            Debug.Log("Box Completed");
        }

    }

    public void AddObject(GameObject gmObj)
    {
        m_AddedObjects.Add(gmObj);
        CheckIfRowCollected();
    }
    public void RemoveObject(GameObject gm)
    {
        if (m_AddedObjects.Count > 0)
            m_AddedObjects.Remove(gm);
    }



}
