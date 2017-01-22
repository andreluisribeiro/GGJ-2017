using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
  public float min = 1, max = 10, limiar = 3.5f;
  public GameObject human, zombie;
  public GameObject paizao;

  // Use this for initialization
  void Start () {
    Invoke("instancia", Random.Range(2, 9));
  }

  void instancia() {
    float r = Random.Range(min, max);

    GameObject go;
    if (r <= limiar) { // spawn a zombie
      go = (GameObject) Instantiate(zombie, transform.position, Quaternion.identity);
    } else { // wait a human
      go = (GameObject) Instantiate(human, transform.position, Quaternion.identity);
    }

    go.transform.parent = paizao.transform;

    Invoke("instancia", Random.Range(2, 9));
  }
}
