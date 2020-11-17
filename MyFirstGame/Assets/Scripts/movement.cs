
using UnityEngine;

public class movement : MonoBehaviour
{
 
    public Rigidbody rb;  

    public float forwardForce = 1000f;
    public float sideForce = 750f;
    // Update is called once per frame
    void FixedUpdate()
    {  
        if(Input.GetKey("a"))
        {
            rb.AddForce(0,0,forwardForce * Time.deltaTime);
        }
        
        if(Input.GetKey("d"))
        {
           rb.AddForce(0,0,-forwardForce * Time.deltaTime); 
        }

        if(Input.GetKey("w")) {
            rb.AddForce(sideForce * Time.deltaTime,0,0);
        
        }
        if(Input.GetKey("s")) 
        {
            rb.AddForce(-sideForce * Time.deltaTime,0,0);
        }    

        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit; 

            //if (Physics.Raycast(ray, out hit, 100)) 
            //{
            //    Interactables interactable1 = hit.collider.GetComponent<Interactables>();
                    
           // }
        }
    }
}
