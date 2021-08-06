using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// скрипт бонусного хп. Прибавляет игроку хп в тот момент, когда он триггерит "сердечко"
/// </summary>
public class BonusHP : MonoBehaviour
{
    private MeshCollider heartCollider;
    private MeshRenderer heartRenderer;
    private AudioSource source;

    private void Start()
    {
        heartCollider = GetComponent<MeshCollider>();
        heartRenderer = GetComponent<MeshRenderer>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InfoClass.hpPlayer ++;

            source.Play();

            heartRenderer.enabled = false;
            heartCollider.enabled = false;
        }
    }
}
