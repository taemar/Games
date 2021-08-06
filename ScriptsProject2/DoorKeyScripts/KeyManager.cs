using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private KeyUp keyUpScript;

    [SerializeField] private GameObject emptyDoorKey;
    [SerializeField] private GameObject pickedDoorKey;
    [SerializeField] private GameObject particleSys;
    [SerializeField] private GameObject keyObject;

    void Update()
    {
        if (keyUpScript.keyUP)
        {
            KeyMechanism();

            keyUpScript.keyUP = false;
        }
    }

    private void KeyMechanism()
    {
        particleSys.SetActive(true);

        Destroy(keyObject);

        emptyDoorKey.SetActive(false);
        pickedDoorKey.SetActive(true);
    }
}
