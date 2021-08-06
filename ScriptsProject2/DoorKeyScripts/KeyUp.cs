using UnityEngine;

public class KeyUp : MonoBehaviour
{
    public bool keyUP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            keyUP = true;
    }

}
