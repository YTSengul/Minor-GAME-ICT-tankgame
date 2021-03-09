using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{

    private const string TANK_FIRE = "Fire1";
    private const string INDESTRUCTIBLE = "indestructible";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit bulletHit;
        if (Input.GetButton(TANK_FIRE))
        {
            Ray shootRay = new Ray(transform.position, transform.up);
            Debug.DrawRay(shootRay.origin, shootRay.direction, Color.blue);

            Physics.Raycast(shootRay, out bulletHit);

            if (bulletHit.transform.tag != INDESTRUCTIBLE)
            {
                Destroy(bulletHit.transform.gameObject);
                Debug.Log(bulletHit.transform.gameObject.name);
            }
        }

    }
}
