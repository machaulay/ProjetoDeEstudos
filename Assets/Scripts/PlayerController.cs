using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public AudioClip[] clips;

    private float horizontal;
    private Vector3 directions;
    private bool is_Firing;
    private bool is_Hit;
    private bool is_Run;
    private Rigidbody rb;
    private Animation an;
    private AudioSource au;
    private CharacterController controller;

    void Start() {

        controller = GetComponent<CharacterController>();
        au = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        an = player.GetComponent<Animation>();


        
    }

    void Update() {

        if (!is_Hit) {
            Control();
            Animations();
        }

        Sounds();
    }

    void Sounds() {
        if (!is_Hit) {
            if (Input.GetAxisRaw("Horizontal") != 0.0f && !is_Run)
            {
                is_Run = true;
                au.clip = clips[0];
                au.loop = true;
                au.pitch = 0.7f; 
                au.Play();
            }else if(Input.GetAxisRaw("Horizontal") == 0.0f && is_Run) {
                is_Run = false;
                au.Stop();
            }
        }
    }

    void Control() {

        if (!is_Firing) {

            //Inputs
            horizontal = Input.GetAxisRaw("Horizontal");

            //Aplicar valores de input (Directions)
            directions = new Vector3(horizontal, 0.0f, 0.0f);

            //orientação
            if (horizontal > 0.0f) {
                player.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }else if (horizontal < 0.0f) {
                player.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
            }

            //Aplica os valores no character controller
            controller.Move(directions * speed * Time.deltaTime);
        }
    }

    void Animations() {

        //Animações
        if (Input.GetAxisRaw("Horizontal") != 0.0f && !is_Firing) {
            an.CrossFade("Run");
        }else if (Input.GetAxisRaw("Horizontal") == 0 && !is_Firing){
            an.Play("Idle");
        }
        
        if (Input.GetButton("Jump") && Input.GetAxisRaw("Horizontal") == 0.0f) {
            horizontal = 0.0f;
            is_Firing = true;
            // an.CrossFade("Fire");
            an.Play("Fire");
        }else if(Input.GetButtonUp("Jump")) {
            is_Firing = false;
        }

    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            StartCoroutine(Hit(1.0f));
        }    
    }

    IEnumerator Hit(float t) {

        au.clip = clips[1];
        au.loop = false;
        au.pitch = 0.1f;
        au.Play();

        is_Hit = true;
        an.CrossFade("Hit");
        yield return new WaitForSeconds(t);
        is_Hit = false;
    }
    
}
