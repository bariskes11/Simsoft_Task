using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    [Tooltip("To set Speed of Item Rotation")]
    public float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1F, 0) * rotateSpeed * Time.deltaTime,Space.World);
    }
}
