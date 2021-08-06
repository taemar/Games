using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// класс, отвечающий за передвижение и прыжок игрока. Также проводит проверку на то, докоснулся ли игрок земли.
/// </summary>
public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody rbPlayer;

    public Transform _camera; // трансформ преследующей игрока камеры
    public float forceMove;   // сила, которая прикладывается к игроку
    public float jumpMove;    // сила, с которой игрок прыгает

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
                rbPlayer.AddForce(_camera.forward * forceMove, ForceMode.Force);

        if (Input.GetKey(KeyCode.A))
                rbPlayer.AddForce(-_camera.right * forceMove, ForceMode.Force);

        if (Input.GetKey(KeyCode.D))
                rbPlayer.AddForce(_camera.right * forceMove, ForceMode.Force);

        if (Input.GetKey(KeyCode.S))
                rbPlayer.AddForce(-_camera.forward * forceMove, ForceMode.Force);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            rbPlayer.AddForce(Vector3.up * jumpMove, ForceMode.Impulse);
        }
    }

    private bool IsGround()
    {
        Ray testRay = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(testRay, out hit, 0.6f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
