using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Image _tutorial;
    public Button _btutorial;
    public Object obj;

    void Start()
    {
        _tutorial.CrossFadeAlpha(0, 0.001f, false);
        _btutorial.targetGraphic.CrossFadeAlpha(0, 0.001f, false);
        _tutorial.CrossFadeAlpha(1, 1, false);
        _btutorial.targetGraphic.CrossFadeAlpha(1, 1, false);
    }

    public void Close()
    {
        _tutorial.CrossFadeAlpha(0, 1, false);
        _btutorial.targetGraphic.CrossFadeAlpha(0, 1, false);
        Invoke("Destroy", 1);
    }

    void Destroy()
    {
        Destroy(obj);
    }
}