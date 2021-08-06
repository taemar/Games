using UnityEngine;

public class LeverManager : MonoBehaviour
{
    [SerializeField] private ArmTrigger armTrigger;
    [SerializeField] private GameObject deactivateObject;

    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (armTrigger.isContact)
        {
            anim.Play();

            deactivateObject.SetActive(false);

            armTrigger.isContact = false;

            Destroy(armTrigger);
        }

    }
}
