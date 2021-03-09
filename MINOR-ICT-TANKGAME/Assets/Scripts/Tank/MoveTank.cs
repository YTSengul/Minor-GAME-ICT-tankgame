using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{

    public int speed = 5;
    public float hightFromFloor = (float)0.2;

    private float diagonalSpeed;
    private const string HORIZONTAL_MOVEMENT = "Horizontal";
    private const string VERTICAL_MOVEMENT = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        // create oscillationg value between -1 and 1 for angle.
        // Turn int into float.
        diagonalSpeed = (float) Mathf.Sin(45);
    }

    // Update is called once per frame
    void Update()
    {
        moveTank();
        rotateTankOnHill();
    }

    // body of thank should be able to move forward and backward. left and right. 
    // no rotation needed. also diagonal. normally diagonally you go faster. 
    // check on this and make this NOT happening! the speed of the tank must me instantanious.

    // Move the tank in the direction you want with the arrow buttons.
    void moveTank()
    {
        float horizontalArrowKeys = Input.GetAxisRaw(HORIZONTAL_MOVEMENT);
        float verticalArrowKeys = Input.GetAxisRaw(VERTICAL_MOVEMENT);

        Vector3 movement = new Vector3(horizontalArrowKeys, 0.0f, verticalArrowKeys);

        if (horizontalArrowKeys != 0 && verticalArrowKeys != 0)
        {
            transform.Translate(movement * speed * diagonalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    // Rotate the tank on plane with same height as before on hill.

    // After sending ray rotate the Y of the tank to the normal of 
    // the plane. so you need to know the difference between ortation 
    // tank and plane. use for this fromtorotation method of Unity. 
    // Video lesson 2 time: 28:11. Quaternion.FromToRotation(Vector3.up, transform.forward)

    // The tank should align itself to the plane. if the plane is normal, tank is normal, if 
    // the plane goes up, tank goes up too. same rotation. the distance between plane and 
    // tank should be keeping the same.

    // Use ray to detect the plane you are. Do this in every update. shoot ray down the tank.
    // Shoot ray and ask plane what it's normal. Then align tank to normal of this plane.

    // Take the place of the hit of the ray and add there the public variable.
    void rotateTankOnHill()
    {
        Ray moveRay = new Ray(transform.position, -transform.up);
        Debug.DrawRay(moveRay.origin, moveRay.direction, Color.blue);

        RaycastHit hit;
        if (Physics.Raycast(moveRay, out hit))
        {
            Vector3 tankNewRotation = Quaternion.FromToRotation(transform.up, hit.normal).eulerAngles;
            tankNewRotation.y = 0;
            transform.Rotate(tankNewRotation);
            transform.position = new Vector3(transform.position.x, (hit.point.y + hightFromFloor), transform.position.z);
        }
    }

}
