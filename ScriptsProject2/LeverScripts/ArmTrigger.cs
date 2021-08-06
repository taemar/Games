using UnityEngine;

public class ArmTrigger : MonoBehaviour
{
    public bool isContact = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isContact = true;
        }
    }
}
