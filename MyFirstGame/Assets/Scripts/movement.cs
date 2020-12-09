
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public Rigidbody rb;

    public float moveSpeed = 5;

    private void Start()
    {
        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
            if (cam == null)
            {
                Debug.LogError("No camera found.");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 _moveDir = new Vector3();
        _moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y,Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        rb.velocity = _moveDir; 

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactables interactable1 = hit.collider.GetComponent<Interactables>();
                Debug.Log("Hit something.");
            }
        }
    }
}
