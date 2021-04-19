using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject[] Points;

    void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(2.0f);
        int randNum = Random.Range(0,2);
        Instantiate(enemy, Points[randNum].transform.position, Points[randNum].transform.rotation);
        StartCoroutine(Spawn());
    }
}
