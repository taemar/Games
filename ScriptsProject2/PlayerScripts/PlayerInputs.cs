using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.InputsVariables
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(JumpAnimation))]
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        private PlayerMovement playerMovement;
        private JumpAnimation jumpAnimation;

        private float horizontal;
        private float vertical;

        void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            jumpAnimation = GetComponent<JumpAnimation>();
        }


        void Update()
        {
            horizontal = Input.GetAxis(GlobalStringVariables.Horizontal_Axis);

            vertical = Input.GetAxis(GlobalStringVariables.Vertical_Axis);

            if (Input.GetButtonDown(GlobalStringVariables.Jump_Button) && IsGround())
            {
                jumpAnimation.animationJump = true;
            }
        }

        private void FixedUpdate()
        {
            if (IsGround())
            {
                playerMovement.MoveCharacter(playerCamera.right.normalized * horizontal);

                playerMovement.MoveCharacter(playerCamera.forward.normalized * vertical);
            }
            else
            {
                playerMovement.MoveCharacterInJump(playerCamera.right.normalized * horizontal);

                playerMovement.MoveCharacterInJump(playerCamera.forward.normalized * vertical);
            }

            if (jumpAnimation.jump && IsGround())
            {
                playerMovement.JumpCharacter();

                jumpAnimation.jump = false;
            }
        }

        private bool IsGround()
        {
            Ray testRay = new Ray(gameObject.transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(testRay, out hit, 2f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
