using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_history : MonoBehaviour {

	public Text txt;
    private int nText;
    public Button next; 
    public Image kenna;
    public Image textbox;

    public Image happy_1;
    public Image happy_2;
    public Image happy_3;
    public Image sad_1;
    public Image sad_2;
    public Image sad_3;

    public Color _color;

    void Start () {
        _color = txt.color;
        _color.a = 0;
        txt.color = _color;

        _color = next.targetGraphic.color;
        _color.a = 0;
        next.targetGraphic.color = _color;

        _color = kenna.color;
        _color.a = 0;
        kenna.color = _color;

        _color = textbox.color;
        _color.a = 0;
        textbox.color = _color;        

        nText = 1;
        txt.text = "Olá, sobreviventes.";
        kenna.sprite = happy_2.sprite;
	}

    void Update() {
        if (_color.a < 1) {
            _color = txt.color;
            _color.a += Time.deltaTime;
            txt.color = _color;

            _color = next.targetGraphic.color;
            _color.a += Time.deltaTime;
            next.targetGraphic.color = _color;

            _color = kenna.color;
            _color.a += Time.deltaTime;
            kenna.color = _color;

            _color = textbox.color;
            _color.a += Time.deltaTime;
            textbox.color = _color;
        }
    }

    public void ChangeImg()
    {
        switch (nText)
        {
            case 1:
                kenna.sprite = happy_2.sprite;
                txt.text = "Meu nome é Kenna, e esta é uma gravação da Oscillation Company.";
                break;
            case 2:
                kenna.sprite = sad_1.sprite;
                txt.text = "O ambiente em que nos encontramos é a perigosa superfície de um mundo devastado," +
                   " cheio de zumbis e humanos remanescentes de uma guerra da qual todos já saíram derrotados." +
                   " Nossa única chance é a luta pela sobrevivência.";
                break;
            case 3:
                kenna.sprite = sad_2.sprite;
                txt.text = "Esta gravação foi deixada na esperança de que possa ser recuperada por humanos com" +
                    " coragem para seguir nossas instruções e salvar a humanidade." +
                    " A área em que vocês se encontram era lar de nossa maior base científica," +
                    " antes de nossos experimentos nos conduzirem ao Grande Erro.";
                break;
            case 4:
                kenna.sprite = sad_3.sprite;
                txt.text = "Nossa equipe construiu uma nave com a capacidade de levar sobreviventes até" +
                    " uma de nossas colônias no espaço, mas um ataque dos canibais - " +
                    "comumente chamados zumbis - destruiu toda a estrutura e aniquilou os humanos." +
                    " Seu objetivo é reconstruir a nave e escapar deste planeta condenado.";
                break;
            case 5:
                kenna.sprite = happy_2.sprite;
                txt.text = "Sucatas podem ser encontradas pela área, use-as para reconstruir as peças usadas na nave." +
                    " Entretanto, vocês precisarão de ajuda! Use os nossos projetos e construa torres que" +
                    " transmitam mensagens de chamada aos humanos sobreviventes e fortaleça suas defesas" +
                    " para mantê-los protegidos.";
                break;
            case 6:
                kenna.sprite = happy_3.sprite;
                txt.text = "Humanos em sua área de proteção o ajudarão a pegar sucata e a manter" +
                    " as estruturas funcionando. Se todos os humanos na área morrerem, " +
                    "a humanidade será condenada à extinção.";
                ++nText;
                break;
            case 7:
                kenna.sprite = happy_1.sprite;
                txt.text = "Boa sorte. Não estrague tudo.";
                break;
            case 8:
                Application.LoadLevel("Main");
                break;
            default:
                txt.text = "Error.";
                break;
        }
        kenna.CrossFadeAlpha(1, 1, false);
        txt.CrossFadeAlpha(1, 1, false);
    }

    public void Next()
    {
        txt.CrossFadeAlpha(0, 1, false);
        kenna.CrossFadeAlpha(0, 1, false);
        Invoke("ChangeImg", 1);
        ++nText;
    }
}
