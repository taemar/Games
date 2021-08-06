using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdoptionScript : MonoBehaviour
{
    public Transform walkingPlatform;
    public Transform SI_hierarchy;
    public Transform playerSystem;

    private void OnCollisionStay(Collision obj)
    {
        if(obj.collider.CompareTag("Player") || obj.collider.CompareTag("SphereInteractive"))
            obj.transform.SetParent(walkingPlatform);
    }

    private void OnCollisionExit(Collision obj)
    {
        switch (obj.collider.tag)
        {
            case "Player":
                obj.transform.SetParent(playerSystem);
                break;

            case "SphereInteractive":
                obj.transform.SetParent(SI_hierarchy);
                break;
        }        
    }

}
