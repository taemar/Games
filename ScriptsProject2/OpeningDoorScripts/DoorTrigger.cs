using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject emptyDoorKey;
    [SerializeField] private GameObject pickedDoorKey;

    public bool promptActivateE;
    public bool DeactivatePrompt;
    public bool StandOnThisTrigger;

    private bool sceneWithKey;

    private void Start()
    {
        if (CheckKey(emptyDoorKey))
            sceneWithKey = true;
        else sceneWithKey = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && sceneWithKey)
        {
            if (pickedDoorKey.activeSelf)
                promptActivateE = true;
        }
        else if (other.CompareTag("Player") && !sceneWithKey)
            promptActivateE = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            StandOnThisTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptActivateE = false;

            DeactivatePrompt = true;

            StandOnThisTrigger = false;
        }
    }

    private bool CheckKey(GameObject emptyDoorKey)
    {
        if (emptyDoorKey.activeSelf)
            return true;
        else return false;
    }
}
