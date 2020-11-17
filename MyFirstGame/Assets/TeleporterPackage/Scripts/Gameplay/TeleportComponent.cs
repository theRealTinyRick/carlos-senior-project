using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    [SerializeField]
    private TeleportComponent siblingTeleporter;

    [SerializeField]
    private Transform spawnPoint;
    public Transform SpawnPoint
    {
        get
        {
            return spawnPoint;
        }
        private set
        {
            spawnPoint = value;
        }
    }

    private bool isRecievingPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if(isRecievingPlayer)
        {
            return;
        }

        if(other.tag == Constants.PLAYER_TAG)
        {
            Teleport(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Constants.PLAYER_TAG)
        {
            isRecievingPlayer = false;
        }
    }

    private void Teleport(GameObject player)
    {
        if (siblingTeleporter != null)
        {
            if(siblingTeleporter.SpawnPoint != null)
            {
                siblingTeleporter.isRecievingPlayer = true;
                player.transform.position =  siblingTeleporter.SpawnPoint.transform.position;
            }
            else
            {
                player.transform.position =  siblingTeleporter.transform.position;
                Debug.LogError("You did not set the spawn point. ");
            }
        }
        else
        {
            Debug.LogError("You did not set the sibling teleporter. ");
        }
    }
}
