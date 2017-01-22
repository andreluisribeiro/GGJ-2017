using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkGenerator : Structures {
    public GameController controller;
    public float time;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("Controller").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    void OnMouseDown()
    {
        controller.junk += (int) time;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("DERECHO");
            GameObject.Find("Controller").GetComponent<GameController>().human.GoTo(this.gameObject);
        }
    }
}
