using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // if player is jumping
        if (anim.GetBool("jumping"))
        {
           //if animatrion is finished
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .9f && !anim.IsInTransition(0))
                // tell the game player isnt jumping
                anim.SetBool("jumping", false);

        }

        // if player presses right or left and is not running
        if (Input.GetButtonDown("Horizontal") && !anim.GetBool("running"))
        {
            // tell the game that the player is running
            anim.SetBool("running", true);
            // then run
            anim.SetTrigger("run");
        }
        if (Input.GetButton("Horizontal"))  ;

        // if player stops pressing right or left
        if (Input.GetButtonUp("Horizontal"))
        {
            // then tell the game that the player isn't running anymore
            anim.SetBool("running", false);
        }

        // if player presses fire
        if (Input.GetButtonDown("Fire1"))
        {
            //if player jumping while fire pressed
            if (anim.GetBool("jumping")) anim.SetTrigger("jump_shoot");
            //if player not jumping while fire pressed
            else anim.SetTrigger("shoot");
        }

        //if player presses melee
        if(Input.GetButtonDown("Fire2"))
        {
            //if player jumping while melee pressed
            if (anim.GetBool("jumping")) anim.SetTrigger("jump_melee");
            //if player not jumping while melee pressed
            else anim.SetTrigger("melee");
        }

        //get if player press down or up 
        if (Input.GetButtonDown("Vertical"))
        {
            // assign which direction was pressed
            var mag = Input.GetAxisRaw("Vertical");

            //if player is running
            if (anim.GetBool("running"))
            {
                // if player pressed down then slide
                if (mag < 0) anim.SetTrigger("slide");
            }
            //if player pressed up
            if (mag > 0)
            {
               //then jump
                anim.SetTrigger("jump");
                //tell the game player still jumping
                anim.SetBool("jumping", true);
            }
        }
    }
}
