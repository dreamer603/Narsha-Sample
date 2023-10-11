using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private bool inArea;

    public int tileSize;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Area"))
        {
            inArea = true;
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Area"))
        {
            inArea = false;
        }
    }
    
    private void Update()
    {
        if (inArea)
        {
            return;
        }
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffZ = Mathf.Abs(playerPos.z - myPos.z);
        
        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirZ = playerDir.z < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffZ)
                {
                    transform.Translate(Vector3.right * dirX * tileSize);
                    inArea = true;
                }
                
                else if (diffX < diffZ)
                {
                    transform.Translate(Vector3.forward * dirZ * tileSize);
                    inArea = true;
                }

                else
                {
                    transform.Translate(Vector3.up * dirX * tileSize);
                    transform.Translate(Vector3.forward * dirZ * tileSize);
                    inArea = true;
                }

                break;
            case "Enemy":

                break;
        }
    }
}