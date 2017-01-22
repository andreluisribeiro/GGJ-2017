using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int junk = 0;
    public Human human;
    public Text junkHUD;
    public float time;

	// Use this for initialization
	void Start () {
            
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        junkHUD.text = "Sucata: " + junk;
        junk += (int) time;
	}

    void CallbackHuman(GameObject sucata)
    {
        human.GoTo(sucata); 
    }

}
