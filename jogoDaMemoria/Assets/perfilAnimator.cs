using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perfilAnimator : MonoBehaviour
{
    public int vez;
    
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

   
    void Update()
    {
        if (vez > gameController.controll.tantoDePlayer - 1)
        {
            anim.SetBool("block", true);
        }

        if (vez == gameController.controll.plIn)
        {
            anim.SetBool("selected", true);
        }
        else
        {
            anim.SetBool("selected", false);
        }
    }
}
