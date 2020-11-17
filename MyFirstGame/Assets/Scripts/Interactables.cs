using UnityEngine;
using UnityEngine.Events;

//public class InteractableEventType : UnityEvent<>

public class Interactables : MonoBehaviour
{
    [SerializeField]
    private KeyCode interactionKey;

    private bool canInteract = false;
    public bool CanInteract {get{return canInteract;}}

    void Update ()
    {
        if(Input.GetKeyDown(interactionKey) && CanInteract)
        {
            Interact();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    private void Interact()
    {
        Debug.Log ("Interact");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = false;
        }
    }





}
