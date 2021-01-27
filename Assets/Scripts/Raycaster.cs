using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // Tells unity that this script needs a camera to work.
public class Raycaster : MonoBehaviour
{


    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // did the user click on this game tick?
        if (cam != null && Input.GetButtonDown("Fire1"))
        {

            // Shoot a ray into the scene

            Ray ray = new Ray(cam.transform.position, cam.transform.forward); // From the camera's position (x,y,z) to the direction the camera is facing
            RaycastHit hit;

            //Draw Ray
            //Debug.DrawRay(ray.origin, ray.direction, Color.black, .5f);

            if (Physics.Raycast(ray, out hit))// out is like a pointer
            {
                // raycast his a collider in the scene!
                // Destroy(hit.collider.gameObject);
                //animIsPlaying = true;

                DoorController door = hit.transform.GetComponentInParent<DoorController>();
                if(door != null)
                {
                    door.PlayerInteract(transform.parent.position);
                }

            }

        }
    }
}
