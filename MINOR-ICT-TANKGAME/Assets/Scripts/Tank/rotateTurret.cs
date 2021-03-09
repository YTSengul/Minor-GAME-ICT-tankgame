using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTurret : MonoBehaviour
{
    public float speed = 30f; //degrees per second

    private const string rotateTurretKeys = "Rotate Turret";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(rotateTurretKeys))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis(rotateTurretKeys) * speed * Time.deltaTime, 0));
        }
    }
}