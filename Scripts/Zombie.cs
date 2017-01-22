using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : CommonBehaviour {
    public bool canHit = true, hit = false;
    public GameObject target;

  //public Animator man, woman;

  // Use this for initialization
  void Start () {
    
    //if (Random.Range(0, 2) <= 1) // man
    //  GetComponent<Animation>().clip = man;
    //else // mulheres
      //GetComponent<Animation>().clip= woman;
    
    SetupAnimator();
  }

  // Update is called once per frame
  void Update () {
        this.Move();
	}

    void Target()
    {
        if (target != null)
        {
            Invoke("Target", .25f);
            target.SendMessage("Hit", this.strength);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "structures")
        {
            target = collider.gameObject;
            this.AntiMove();
            velocidade = 0;
            Invoke("Target", .5f);
            
        }
    }
    
}
