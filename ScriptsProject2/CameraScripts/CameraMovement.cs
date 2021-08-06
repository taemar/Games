using UnityEngine;

namespace WildBall.InputsVariables
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float senseMouse;
        [SerializeField] private float smooth;
        [SerializeField] private float speedTowards;

        [SerializeField] private Transform playerPosition;
        [SerializeField] private Transform cameraPosition;
        [SerializeField] private Transform startCameraPos;
        [SerializeField] private Transform endCameraPos;

        [SerializeField] private CameraTriggerWall camTriggerWall;

        private Transform cameraRotator;

        void Start()
        {
            cameraRotator = GetComponent<Transform>();
        }
        
        void FixedUpdate()
        {
            cameraRotator.Rotate(0, senseMouse * Input.GetAxis(GlobalStringVariables.Mouse_X), 0);
            
            transform.position = playerPosition.position;

            CameraLimitMovement(smooth, speedTowards);
        }

        private void CameraLimitMovement(float smooth, float speed)
        {
            if(camTriggerWall.cameraTrigger)
            {
                cameraPosition.position = Vector3.Lerp(cameraPosition.position, endCameraPos.position, Time.deltaTime * smooth);
            }

            if(!camTriggerWall.cameraTrigger && (cameraPosition.position != startCameraPos.position))
            {
                cameraPosition.position = Vector3.MoveTowards(cameraPosition.position, startCameraPos.position, Time.deltaTime * speed);
            }
        }

    }
}
