using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveHandle : MonoBehaviour
{
    public float x; // новые координаты рукояти рычага
    public float y;
    public float z;
    public float rotationZ;

    private Transform positionHandle;
    private AudioSource source;

    private void Start()
    {
        positionHandle = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && SceneManager.GetActiveScene().name == "2 level")
        {
            source.Play();

            positionHandle.position = new Vector3(x, y, z);
            positionHandle.rotation = Quaternion.Euler(0, 0, rotationZ);

            InfoClass.bridgeActivate = 2;
        }
    }
}
