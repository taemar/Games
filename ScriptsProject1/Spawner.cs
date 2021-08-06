using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// возвращает интерактивную сферу в точку спавна всякий раз, когда ее коорд. Y оказывается меньше координаты Y Death Zone-ы.
/// </summary>
public class Spawner : MonoBehaviour
{
    public Transform pointPosition; // начальная позиция объекта.
    public float distanceBeforeStartResp; // расстояние, на которое упадет интеракт. сфера, прежде чем зареспится обратно.

    private Transform positionSphere; // позиция сферы в кадре.
    private AudioSource source;

    private void Start()
    {
        positionSphere = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Player"))
            source.Play();
    }

    private void Update()
    {
        if (positionSphere.position.y < -distanceBeforeStartResp)
            positionSphere.position = pointPosition.position;

    }
}
