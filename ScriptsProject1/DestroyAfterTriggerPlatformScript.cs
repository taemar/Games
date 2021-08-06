using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyAfterTriggerPlatformScript : MonoBehaviour
{
    public float musicDelay;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            source.Play();

            Destroy(gameObject, musicDelay);
        }
    }
}
