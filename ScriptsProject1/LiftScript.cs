using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    public Transform startPosition;  // начальная позиция платформы
    public Transform finishPosition; // конечная позиция платформы

    public float speed;  // скорость хождения платформы

    private Transform tfLift;
    private Vector3 routeLift;    // вектор направления движения платформы

    private bool switcher = true; // переключатель направлений движения

    void Start()
    {
        routeLift = finishPosition.position - startPosition.position;
        routeLift = routeLift.normalized;

        tfLift = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (switcher)
        {
            tfLift.Translate(routeLift * speed * Time.fixedDeltaTime, finishPosition);
        }
        else
            tfLift.Translate(routeLift * (-speed) * Time.fixedDeltaTime, startPosition);


        if (tfLift.position.x > finishPosition.position.x ||
            tfLift.position.y > finishPosition.position.y ||
            tfLift.position.z > finishPosition.position.z)
        {
            switcher = false;
        }
        else 
        if (tfLift.position.x < startPosition.position.x ||
            tfLift.position.y < startPosition.position.y ||
            tfLift.position.z < startPosition.position.z)
        {
                switcher = true;
        }
    }
}
