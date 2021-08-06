using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPlatform: MonoBehaviour
{
    public Transform startPosition;  // начальная позиция платформы
    public Transform finishPosition; // конечная позиция платформы
    public float speed;

    private bool switcher = false;
    private bool oneTime = true;
    private bool oneTime1 = true;

    private Transform tfPlatform;
    private AudioSource audioSource;

    private void OnCollisionStay(Collision obj)
    {
        if (obj.collider.CompareTag("Player"))
            switcher = true;
    }

    private void OnCollisionExit(Collision obj)
    {
        if (obj.collider.CompareTag("Player"))
            switcher = false;
    }

    private void Start()
    {
        tfPlatform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (tfPlatform.position.y < finishPosition.position.y && switcher)
        {
            tfPlatform.Translate(transform.up * speed * Time.fixedDeltaTime, finishPosition);

            if (tfPlatform.position.y > finishPosition.position.y && oneTime)
            {
                oneTime1 = false;
                oneTime = false;

                if(audioSource.isPlaying)
                    audioSource.Stop();

                audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/stoplift"));
            }

            if (!audioSource.isPlaying && oneTime1)
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/liftMove"));
            }

        }
        else if(tfPlatform.position.y > startPosition.position.y && !switcher)
        {
            tfPlatform.Translate(-transform.up * speed * Time.fixedDeltaTime, startPosition);

            if(tfPlatform.position.y == startPosition.position.y && !oneTime)
            {
                oneTime1 = true;
                oneTime = true;

                if (audioSource.isPlaying)
                    audioSource.Stop();
            }

            if(!audioSource.isPlaying && !oneTime1)
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/liftMove"));
            }
        }
    }

}
