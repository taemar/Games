using UnityEngine;

public class SwitchingAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void NextAnimation()
    {
        int randNumber = Random.Range(0,4);

        anim.SetInteger("SerialNumber", randNumber);
    }
}
