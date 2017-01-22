using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : CommonBehaviour     {
    GameObject target;
    
	void Start () { 
        SetupAnimator();
  }
	
	// Update is called once per frame
	void Update () {
        this.Move();
	}

    public void GoTo(GameObject go)
    {
        Vector3 relative = transform.InverseTransformPoint(go.transform.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        velocidade = 2;
        this.ApplyTarget(angle);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("DERECHO");
            GameObject.Find("Controller").GetComponent<GameController>().human = this;


        }
    }

    void Target()
    {
        if (target != null)
        {
            Invoke("Target", .5f);
            target.SendMessage("OnMouseDown");
        }

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "structures" && collider.gameObject.GetComponent<JunkGenerator>() != null)
        {
            
            target = collider.gameObject;
            this.AntiMove();
            velocidade = 0;
            Invoke("Target", .5f);

        }
    }
}
