using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform doorArt;


    // The angle of the door in degrees
    private float doorAngle = 0;

    public float animLength = 0.5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;


    private bool isClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {

       

        //Play the animation

        if(animIsPlaying)
        {
            if (!isClosed)
            animTimer += Time.deltaTime; // Playing forward
            else
                animTimer -= Time.deltaTime; // Playing backward

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed) 
            {
                percent = 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed)
            {
                percent = 1;
                animIsPlaying = false;
            }
            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); // Set angle of doorArt
        }
        
    }

    private void OnMouseEnter() // This event triggers when the cursor is over the object.
    {
        //print("mouse over!");
    }
    private void OnMouseDown() // This event triggers when the user clicks on the object.
    {
        //print("Mouse Pressed!");
        // Change Something
        //Destroy(gameObject);
    }

    public void PlayerInteract(Vector3 position)
    {
        if (animIsPlaying) return; // Skips everything else in the function
        if (!Inventory.main.hasKey) return;

        Vector3 disToPlayer = position - transform.position;

        disToPlayer = disToPlayer.normalized;

        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.right) > 0);

        if (!isClosed)
        {
            doorAngle = 90;
            if (playerOnOtherSide) doorAngle = -90;
        }

        // if (!isClosed) doorAngle = (playerOnOtherSide) ? -90 : 90; // Turnary Operator Google.

        isClosed = !isClosed; // toggles the state
        
        animIsPlaying = true;

        // Set playhead to end or beginning
        if (isClosed) animTimer = animLength;
        else animTimer = 0;
    }

}
