using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {
	void Start () {}
	void Update () {}

    public abstract void treatClick();
    private void OnMouseDown() {
        treatClick();
    }
}
