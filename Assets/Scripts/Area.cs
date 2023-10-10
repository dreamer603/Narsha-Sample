using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        Vector3 playerPosition = transform.position;
        
        playerPosition.x = player.position.x;
        playerPosition.z = player.position.z;
        
        transform.position = playerPosition;

    }
}
