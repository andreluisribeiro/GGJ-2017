using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketBase : MonoBehaviour {
    public Canvas c;
  public bool n;

	// Use this for initialization
	void Start () {
    n = true;
    OnMouseDown();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
    Debug.Log("VAI");
        n = !n;
        c.gameObject.SetActive(n);
    }
}
