using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public GameObject meshCharacter;
    public float speed;
    public float impulse;
    public float gravity;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animation anim;

    void Start() {
        controller = GetComponent<CharacterController>();
        anim = meshCharacter.GetComponent<Animation>();

    }


    void Update() {
        
        if (controller.isGrounded) {
            //Move
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        //Animation
        if (moveDirection.x == 0.0f && moveDirection.z == 0.0f) {
            
            anim.CrossFade("Idle");
        }else{
            
            anim.CrossFade("Run");
        }

        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Apply Values in Character Controller(move and gravity)
        controller.Move(moveDirection * Time.deltaTime);

        
         
    }



}
