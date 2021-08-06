using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отключает переключатель после попадания в него интерактивной сферы. Включает переключатель, когда игрок умирает три раза.
/// </summary>
public class GateSwitch : MonoBehaviour
{
    private AudioSource doublePlayerSource;

    private void Start()
    {
        doublePlayerSource = GameObject.Find("Player/Other sounds").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SphereInteractive")) // когда в переключатель попадает нпс-сфера...
        {            
            InfoClass.gateSwitches++; // сообщаем в InfoClass, что один переключатель активирован.

            doublePlayerSource.PlayOneShot(Resources.Load<AudioClip>("Audio/switcher_sound"));

            gameObject.SetActive(false);
        }
    }
}
