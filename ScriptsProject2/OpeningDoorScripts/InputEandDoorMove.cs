using UnityEngine;

public class InputEandDoorMove : MonoBehaviour
{
    [SerializeField] private Transform pointAround;
    [SerializeField] private DoorTrigger doorTrigger;
    [SerializeField] private GameObject promptPressE;
    [SerializeField] private GameObject pickedKey;
    [SerializeField] private GameObject emptyKey;

    [SerializeField] private float speed;
    [SerializeField] private float angle;

    private bool openDoor;

    public bool offPromptPressE;

    private void Awake()
    {
        offPromptPressE = true;
    }

    private void Update()
    {
        if(promptPressE.activeSelf && Input.GetKeyDown(KeyCode.E) && doorTrigger.StandOnThisTrigger)
        {
            if (pickedKey.activeSelf)
            {
                pickedKey.SetActive(false);

                emptyKey.SetActive(true);
            }

            openDoor = true;

            promptPressE.SetActive(false);

            offPromptPressE = false;
        }
    }

    void FixedUpdate()
    {
        if (openDoor && transform.eulerAngles.y < angle)
        {
            transform.RotateAround(pointAround.position, Vector3.up, speed * Time.deltaTime);
        }
        else if (transform.eulerAngles.y > angle)
        {
            openDoor = false;
        }
    }
}
