using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed;
   public GameObject particle;

    void Update() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col) {
       GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
       Destroy(p, 2.0f);
       Destroy(gameObject);
    }
}
