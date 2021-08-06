using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private GameObject startWall;
    [SerializeField] private Transform endPosWall;
    [SerializeField] private WallTrapActivate wallTrapActivate;
    [SerializeField] private float speedWall;

    private bool letsMove = false;

    void Update()
    {
        if (wallTrapActivate.timeToMove)
        {
            startWall.SetActive(true);

            letsMove = true;

            wallTrapActivate.timeToMove = false;
        }
                
    }

    void FixedUpdate()
    {
        if (startWall.transform.position == endPosWall.position)
            letsMove = false;

        if (letsMove)
        {
            startWall.transform.position = Vector3.MoveTowards(startWall.transform.position, endPosWall.position, speedWall * Time.deltaTime);
        }
    }
}
