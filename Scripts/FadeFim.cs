using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFim : MonoBehaviour {
  public Image antes, depois;

	// Use this for initialization
	void Start () {
    depois.CrossFadeAlpha(0, 0.001f, false);
    antes.CrossFadeAlpha(0, 1.7f, false);
    Invoke("vaidepois", 1.3f);
	}
	
  public void vaidepois() {
    depois.CrossFadeAlpha(1, 1.7f, false);
    Invoke("voltamenu", 1.3f);
  }

  public void voltamenu() {
    depois.CrossFadeAlpha(0, 1.7f, false);
    Invoke("agoravai", 1.3f);
  }

  public void agoravai() {

    Application.LoadLevel(0);

  }

  // Update is called once per frame
  void Update () {
		
	}
}
