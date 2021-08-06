using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool oneTimeSound = true; // булева переменная, воспроизводящая звук чекпоинта только при первом триггере
    
    private AudioSource doublePlayerSource;
    private Transform tr;
    private AudioSource source;

    private void Start()
    {
        doublePlayerSource = GameObject.Find("Player/Other sounds").GetComponent<AudioSource>();

        tr = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InfoClass.lastCheckPoint = tr.position;

            InfoClass.checkpointTest = true;

            if (oneTimeSound)
            {
                source.Play();

                oneTimeSound = false;
            }

            if (InfoClass.sound_afterDeath)
            {
                doublePlayerSource.PlayOneShot(Resources.Load<AudioClip>("Audio/new_life_sound"));

                InfoClass.sound_afterDeath = false;
            }
        }
    }

    private void Update()
    {
        if (InfoClass.hpPlayer == 0)
        {
            InfoClass.checkpointTest = false;

            oneTimeSound = true;
        }
    }
}
