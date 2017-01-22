using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : Structures {
    private int limit = 10;
    public int actual = 0;
    public GameObject humano;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        limit = this.tier * 15;
	}

    void OnTriggerEnter(Collider other)
    {
        if(actual < limit && other.gameObject.tag == "humano")
        {
            Destroy(other.gameObject);
            actual++;
        }
    }

    void OnDestroy()
    {
        int i,j,k = actual;
        for(i = 0; i < (int) Mathf.Sqrt(actual); i++)
        {
            for(j = 0; j < (int) Mathf.Sqrt(actual); j++)
            {
                k--;
                Instantiate(humano, transform.position + new Vector3(i, 0, j), transform.rotation);
            }
        }
        if(k != 0)
        {
            i++;
            for (j = 0; k > 0; j++, k--)
            {
                Instantiate(humano, transform.position + new Vector3(i, 0, j), transform.rotation);
            }
        }
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
