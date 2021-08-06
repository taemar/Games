using UnityEngine;

public class PromptsActiveCanvas : MonoBehaviour
{
    [SerializeField] private GameObject promptPressE;
    [SerializeField] private DoorTrigger doorTrigger;
    [SerializeField] private InputEandDoorMove doorScript;

    void Update()
    {
        if (doorTrigger.promptActivateE && doorScript.offPromptPressE)
        {
            promptPressE.SetActive(true);
        }
        
        if(doorTrigger.DeactivatePrompt)
        {
            promptPressE.SetActive(false);
            doorTrigger.DeactivatePrompt = false;
        }
    }
}
