using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatformScript : MonoBehaviour
{
    public float disappearDelay;
    public float music_time;

    private bool startTimer = false;
    private AudioSource platfSource;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            startTimer = true;
    }

    private void Start()
    {
        platfSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (startTimer)
        {
            if(disappearDelay > 0)
            {
                disappearDelay -= Time.fixedDeltaTime;
            }
            else if(disappearDelay < 0)
            {
                startTimer = false;
                Destroy(gameObject);
            }
            
            if (disappearDelay < music_time && !platfSource.isPlaying)
            {
                platfSource.Play();
            }
        }

        
    }



}
