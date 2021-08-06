using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAfter3Death : MonoBehaviour
{
    public AudioClip sound3Death;
    public AudioClip soundDeath;

    private AudioSource source;
    private bool oneTime = true;
        
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InfoClass.sound_after3Death) // если игрок триггернул и умер три раза
            {
                source.PlayOneShot(sound3Death);

                InfoClass.sound_after3Death = false;
            } 
            else if (!InfoClass.checkpointTest && InfoClass.hpPlayer < 3 && oneTime) // если игрок триггернул и еще не проходил чекпоинт
            {
                source.PlayOneShot(soundDeath);

                oneTime = false;
            }

        }
    }

    private void Update()
    {
        if (InfoClass.deadTest)
            oneTime = true;
    }


}
