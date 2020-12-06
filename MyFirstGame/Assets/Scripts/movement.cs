using UnityEngine;
public class movement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Rigidbody rigidbody;

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

        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
            if (rigidbody == null)
            {
                Debug.LogError("No rigidbody found.");
            }
        }
    }

    private void Update()
    {
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

    private void FixedUpdate()
    {
        Vector3 _right = Input.GetAxis("Vertical") * transform.right;
        Vector3 _forward = -Input.GetAxis("Horizontal") * transform.forward;
        Vector3 _moveDir = _right + _forward;
        _moveDir = new Vector3(_moveDir.x * moveSpeed, rigidbody.velocity.y, _moveDir.z * moveSpeed);
        
        rigidbody.velocity = _moveDir;
    }
}