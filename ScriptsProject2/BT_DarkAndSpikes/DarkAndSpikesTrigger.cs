using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAndSpikesTrigger : MonoBehaviour
{
    public bool triggerPassed;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            triggerPassed = true;
    }

}
