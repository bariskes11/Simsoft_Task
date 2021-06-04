using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomLevel : MonoBehaviour
{
    // anypossible gameobject in box
    [Tooltip("Any possible gameobject in box")]
    public GameObject[] ObjectTypes;
    // totalboxCount in the game
    [Tooltip("total Box Count in the game")]
    public int BoxCount;
    // Start is called before the first frame update
    void Start()
    {

        int Len = ObjectTypes.Length;
        if (Len == 0)
        {
            Debug.Log(" Please Add GameObjects on 'ObjectTypes'");
            return;
        }

        foreach (var item in ObjectTypes)
        {

        }
    }

   
}
