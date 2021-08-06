using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3DActivator : MonoBehaviour
{
    [SerializeField] private GameObject textstart;
    [SerializeField] private GameObject textfinish;
    [SerializeField] private WallTrapActivate trapActivate;

    private int counter;

    private void Awake()
    {
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter++;

            if(counter == 1)
                textstart.SetActive(true);

            if (counter > 1 && (counter % 2 == 1))
                textstart.SetActive(true);

            if (counter > 1 && (counter % 2 == 0))
                textstart.SetActive(false);
        }
    }

    private void Update()
    {
        if (trapActivate.nextText)
        {
            if (textstart.activeSelf)
                textstart.SetActive(false);

            textfinish.SetActive(true);

            trapActivate.nextText = false;
        }
    }

}
