using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InfoClass.deadTest = true;

            if (InfoClass.hpPlayer == 1)
                InfoClass.hpPlayer = 0;
        }
    }

}
