using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string OpenTrigger = "OpenDoor";
    
    [SerializeField]
    private string CloseTrigger = "CloseDoor";

    private bool isOpen = false;

    void Start()
    {
        if(animator == null)        
        {
            animator = GetComponent<Animator>();
            if(animator == null)
            {
                Debug.LogError("No animator found.");
            }
        }
    }

    public void Open()
    {
        if(isOpen) return;

        if(animator != null)
        {
            animator.SetTrigger(OpenTrigger);
            isOpen = true;
        }
    }   

    public void Close()
    {
        if(!isOpen) return;

        if(animator != null)
        {
            animator.SetTrigger(CloseTrigger);
            isOpen = false;
        }
    }
}
