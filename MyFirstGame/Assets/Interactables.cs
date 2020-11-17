using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 3f; 
    
    Transform player;
        void Update (){
    if(distance <= radius){
        Debug.Log ("Interact");

    }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }







}
