using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour {

    private PlayerMovement c_movement;  //Reference to PlayerMovement script
    private bool isJumping;             //To determine if the player is jumping
    private Player_Shoot c_Shoot;

	void Awake()
    {
        //References
        c_movement = GetComponent<PlayerMovement>();
        c_Shoot = GetComponent<Player_Shoot>();
    }
	
	void Update ()
    {
        //If he is not jumping...
	    if (!isJumping)
        {
            //See if button is pressed...
            isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
        }
       
        if(Input.GetButtonDown("Fire1") && c_Shoot.fireRate == 0)
        {
            c_Shoot.OnShoot();
        }
        if(Input.GetButton("Fire1") && c_Shoot.fireRate >0)
        {
            c_Shoot.OnShoot();
        }
    }

    private void FixedUpdate()
    {
        //Get horizontal axis
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //Call movement function in PlayerMovement
        c_movement.Move(h, isJumping);
        //Reset
        isJumping = false;
    }
}
