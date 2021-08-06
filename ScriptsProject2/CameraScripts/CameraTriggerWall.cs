using UnityEngine;

public class CameraTriggerWall : MonoBehaviour
{
    public bool cameraTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            cameraTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            cameraTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            cameraTrigger = false;
        }
    }
}
