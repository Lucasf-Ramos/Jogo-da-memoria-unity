using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardAnimatic : MonoBehaviour
{
    public int fase;
    public bool final;
    public int turn;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (!final)
        {
            turn = gameController.controll.turn;
           
                fase = gameController.controll.fase;
                anim.SetInteger("cardFase", fase);
           
            if(fase == 2)
            {
                //final = true;
                anim.SetInteger("cardFase", fase);
            }
        }
        else
        {
           
            gameController.controll.fase = 0;
          
        }
    }
}
