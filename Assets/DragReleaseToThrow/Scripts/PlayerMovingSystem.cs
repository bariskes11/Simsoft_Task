using System.Collections;
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
        direction.x = direction.z;
        direction.z = 1;
        direction.y = 0;
        rb.AddRelativeForce(direction * Mathf.Clamp(Mathf.Abs(power), 0, 10) , ForceMode.Impulse);

    }
}
