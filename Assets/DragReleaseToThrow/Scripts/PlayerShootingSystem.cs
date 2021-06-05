using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingSystem : MonoBehaviour
{

    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;
    public GameObject Arrow;
    public GameObject ArrowFiller;
    public PlayerMovingSystem Player;
    private Vector3 currentDirection;
    private float currentForce;
    public GameObject CanvasDisplay;
    // maximum x Rotation
    public float MaxXAngle = 45;
    public float MaxPower = 100;
    private Image fillerImage;
    private void Start()
    {
        fillerImage = ArrowFiller.GetComponent<Image>();
        fillerImage.fillAmount = 0;
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (currentForce != 0 && currentDirection != Vector3.zero)
            {
                CanvasDisplay.SetActive(false);
                Player.MovePlayer(currentDirection, currentForce);
            }
            Reset();
        }


        // Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Did we cross the deadzone
        if (swipeDelta.magnitude > 1)
        {
            //swipe Direciton
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            Debug.Log("Swipe Direction x:" + x + " y:" + y);
            float rotationz = -Mathf.Clamp(x, -MaxXAngle, MaxXAngle);
            
            Quaternion r = Quaternion.Euler(new Vector3(Arrow.transform.rotation.x, Arrow.transform.rotation.y, rotationz)); // rotates the arrow to swipped position
            currentDirection = new Vector3(Arrow.transform.rotation.x, Arrow.transform.rotation.y, rotationz);
            Arrow.transform.localRotation = r;
            if (y < 0)
            {
                fillerImage.fillAmount = Mathf.Clamp(Mathf.Abs(y), 0, MaxPower) / 100;//sets current fill Amount
                currentForce = fillerImage.fillAmount * 100;
            }

        }

    }
    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
        currentDirection = Vector3.zero;
        currentForce = 0;
    }
}
