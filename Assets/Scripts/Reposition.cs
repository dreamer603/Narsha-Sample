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
            Debug.Log("닿음");
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Area"))
        {
            inArea = false;
            Debug.Log("안닿음");
        }
    }
    
    private void Update()
    {
        if (inArea)
        {
            return;
        }
        
        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirZ = playerDir.z < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                transform.Translate(Vector3.forward * dirZ * tileSize);
                inArea = true;
                break;

            case "Enemy":

                break;
        }
    }
}