using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{
    public float senseMouse; // скорость вращения камеры
    public Transform objToFollow; // объект игрока

    private Transform tfCamera;

    private void Start()
    {
        tfCamera = GetComponent<Transform>();
    }


    void Update()
    {
        tfCamera.Rotate(0, senseMouse * Input.GetAxis("Mouse X"), 0);

        tfCamera.position = objToFollow.position;
    }
}
