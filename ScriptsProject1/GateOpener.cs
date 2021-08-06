using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// класс, открывающий ворота после того, как были преодолены quantitySwitch переключателей.
/// </summary>
public class GateOpener : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 routeVector;     // вектор направления движения

    private AudioSource gateSource;
    private Transform tfGate;

    private bool playOneMore = true;
    private bool optimize = false;
    private bool gateIsMove = true;

    public Transform gateOpener;
    public byte quantitySwitch; // количество переключателей, нужное для открытия ворот
    public float movespeedGate;


    private void OnCollisionEnter(Collision obj)
    {
        switch (obj.gameObject.tag)
        {
            case "GateOpener":
                gateIsMove = false;
                break;

            case "Player":
                gateSource.PlayOneShot(Resources.Load<AudioClip>("Audio/bound_of_Gate"));
                break;
        }
    }

    void Start()
    {
        tfGate = GetComponent<Transform>();
        gateSource = GetComponent<AudioSource>();

        startPosition = tfGate.position;

        routeVector = gateOpener.position - startPosition;
        routeVector = routeVector.normalized;
    }

    void FixedUpdate()
    {
        if(InfoClass.gateSwitches == quantitySwitch)
        {
            optimize = true;

            if (playOneMore)
            {
                gateSource.Play();

                playOneMore = false;
            }

            if (gateIsMove)
            {
                tfGate.Translate(routeVector * movespeedGate * Time.fixedDeltaTime, gateOpener);
            }
        }

        if (InfoClass.gateSwitches == 0 && optimize)
        {
            tfGate.position = startPosition;

            playOneMore = true;
            optimize = false;
            gateIsMove = true;
        }

    }
}
