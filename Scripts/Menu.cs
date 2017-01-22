using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Text nameText;
    public Text playText;
    public Text quitText;
    public Text creditsText;
    public Button playButton;
    public Button quitButton;
    public Button creditsButton;
    public Text txt;

    private Color _color;
    private bool b_credits;

    void ChanceScene() {
        Application.LoadLevel("History");
    }

    void QuitGame() {
        Application.Quit();
    }

    void CreditsGame() {
        b_credits = !b_credits;
    }

    void Start() {
        b_credits = false;
        _color = txt.color;
        _color.a = 0;
        txt.color = _color;

        txt.text = "CRÉDITOS:\n\nArte: \nTalita Halboth\nColaboração de Stephanie Americo"+
            "\n\nProgramação: \nAndré Ribeiro\nGabriel Candido\nStephanie Americo";
    }

    void Update() {
        if (b_credits) {
            if (_color.a < 1) {
                _color = txt.color;
                _color.a += Time.deltaTime;
                txt.color = _color;
            }
        }
        else if (!b_credits && txt.color.a > 0) {
            Debug.Log("oi");
            txt.CrossFadeAlpha(0, 1, false);

            nameText.CrossFadeAlpha(1, 1, false);
            playText.CrossFadeAlpha(1, 1, false);
            quitText.CrossFadeAlpha(1, 1, false);
            creditsText.CrossFadeAlpha(1, 1, false);
            playButton.targetGraphic.CrossFadeAlpha(1, 1, false);
            quitButton.targetGraphic.CrossFadeAlpha(1, 1, false);
        }
            
    }

    public void Play () {
        nameText.CrossFadeAlpha(0, 1, false);
        playText.CrossFadeAlpha(0, 1, false);
        quitText.CrossFadeAlpha(0, 1, false);
        creditsText.CrossFadeAlpha(0, 1, false);
        playButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        quitButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        creditsButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        Invoke("ChanceScene", 1);
    }

    public void Quit() {
        nameText.CrossFadeAlpha(0, 1, false);
        playText.CrossFadeAlpha(0, 1, false);
        quitText.CrossFadeAlpha(0, 1, false);
        creditsText.CrossFadeAlpha(0, 1, false);
        playButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        quitButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        creditsButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        Invoke("QuitGame", 1);
    }

    public void Credits() {
        nameText.CrossFadeAlpha(0, 1, false);
        playText.CrossFadeAlpha(0, 1, false);
        quitText.CrossFadeAlpha(0, 1, false);
        creditsText.CrossFadeAlpha(0, 1, false);
        playButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        quitButton.targetGraphic.CrossFadeAlpha(0, 1, false);
        Invoke("CreditsGame", 1);
    }
}
