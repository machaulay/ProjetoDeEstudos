using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject particle;
    public Transform weaponRotation;

    void Start() {
        
    }
    
    void Update() {

        if (Input.GetAxisRaw("Horizontal") > 0.0f) {
            weaponRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            
        }else if(Input.GetAxisRaw("Horizontal") < 0.0f) {
            weaponRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }


        if (Input.GetButtonDown("Jump")) {
            //bullet
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position;
            b.transform.eulerAngles = weaponRotation.eulerAngles;

            //Particula de disparo
            Destroy(Instantiate(particle, transform.position, Quaternion.identity), 0.08f);
        }
    }
}
