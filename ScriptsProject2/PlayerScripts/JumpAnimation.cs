using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    private Animator anim;
    public bool jump;
    public bool animationJump;

    void Start()
    {
        anim = GetComponent<Animator>();
        jump = false;
        animationJump = false;
    }

    private void Update()
    {
        if (animationJump)
        {
            anim.SetBool("LetsGo", true);

            animationJump = false;
        }
    }

    public void StopAnimationAndJump()
    {
        anim.SetBool("LetsGo", false);

        jump = true;
    }

    public void AntiDoubleJump()
    {
        animationJump = false;
    }
}
