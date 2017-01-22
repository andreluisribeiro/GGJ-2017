using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    public Canvas c;
    private GameController gc;

    private int ungrab = 0;

    public GameObject[] antena;
    public GameObject item, casa;

    public float[] multiplierAntenna = new float[5] { 1, 1, 1, 1, 1 };
    public float multiplierHome = 1;

    public int[] basePriceAntenna = new int[5] { 150, 150, 150, 150, 150 };
    public int basePriceHome = 400;

    public Text labelHome;
    public Text[] labelAntenna;

  public Image basecompleta;

  public int tamanho;


  public Sprite[] estagios;
  public Sprite[] pecas;
  private int stage = 0;

  public int basePricePiece = 20000;
  public int multiplierPiece = 1;
  public Text labelPiece;
  public Button piecetobuy;

  public void Start()
    {
    stage = 0;
        gc = GameObject.Find("Controller").GetComponent<GameController>();
        labelHome.text = ((int)(basePriceHome * multiplierHome)) + "";
        for (int i = 0;i < 5; i++)
          labelAntenna[i].text = ((int)(basePriceAntenna[i] * multiplierAntenna[i])) + "";
    }

    public void BuyAntenna(int i)
    {
    Debug.Log("COMPROU ANTENNA");
        if(basePriceAntenna[i] * multiplierAntenna[i] <= gc.junk)
        {
            GameObject.Find("Base").SendMessage("OnMouseDown");
            item = (GameObject) Instantiate(antena[i], this.transform.position, Quaternion.identity);
            gc.junk -= (int) (basePriceAntenna[i] * multiplierAntenna[i]);
            multiplierAntenna[i] *= 2f;
            labelAntenna[i].text = ((int)(basePriceAntenna[i] * multiplierAntenna[i])) + "";
        }
    }

  public void BuyPiece() {
      stage++;
    Debug.Log("ESTAIOG: "+ stage);
    if (stage < tamanho -1) {
      basecompleta.sprite = estagios[stage];
      piecetobuy.GetComponent<Image>().sprite = pecas[stage];
      multiplierPiece += 2;
    } else if (stage == tamanho-1) {
      basecompleta.sprite = estagios[stage];

      Destroy(piecetobuy.gameObject);
      Application.LoadLevel(3);
    }
  }

    public void BuyHome()
    {
        if (basePriceHome * multiplierHome <= gc.junk)
        {
            GameObject.Find("Base").SendMessage("OnMouseDown");
            item = (GameObject)Instantiate(casa, this.transform.position, Quaternion.identity);
            gc.junk -= (int)(basePriceHome * multiplierHome);
            multiplierHome *= 2f;
            labelHome.text = ((int)(basePriceHome * multiplierHome)) + "";
        }
    }

    void Update()
    {
        if(item != null)
        {
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            item.transform.position = curPosition;
            if(Input.GetMouseButtonUp(0))
            {
                ungrab++;
            }
            if(ungrab > 1)
            {
                ungrab = 0;
                item = null;
            }
        }
    }

}
