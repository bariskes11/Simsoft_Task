﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSystem : MonoBehaviour
{
    public float moveSpeed;
    public float MaxSpeed=10F;
    private Rigidbody rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void  MovePlayer(Vector3 direction, float power)
    {
        direction.x = 0;
        direction.y =- direction.z;
        direction.z = 0;
        this.transform.Rotate(direction);
       rb.AddForce(transform.forward * Mathf.Clamp(Mathf.Abs(power), 0, 100) , ForceMode.Impulse);

    }
}
