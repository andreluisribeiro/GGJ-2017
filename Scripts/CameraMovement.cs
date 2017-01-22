using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int velocidade = 10;
    
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKey("d")) transform.Translate(velocidade * Vector3.right * Time.deltaTime, Space.World);
        if (Input.GetKey("a")) transform.Translate(velocidade * Vector3.left * Time.deltaTime, Space.World);
        if (Input.GetKey("w")) transform.Translate(velocidade * Vector3.down * Time.deltaTime, Space.World);
        if (Input.GetKey("s")) transform.Translate(velocidade * Vector3.up * Time.deltaTime, Space.World);

        // bottom left is 0, 0
        double right_limiar = Screen.width - (Screen.width * 0.15);
        double left_limiar = Screen.width * 0.15;
        double top_limiar = Screen.height - (Screen.height * 0.15);
        double bottom_limiar = Screen.height * 0.15;

        double mouseX = Input.mousePosition.x;
        double mouseY = Input.mousePosition.y;
        if (mouseX >= 0 && mouseX <= left_limiar) { // left side of screen
          if (mouseY >= 0 && mouseY <= bottom_limiar) { // bottom-left corner
              transform.Translate(velocidade * Vector3.left * Time.deltaTime, Space.World);
              transform.Translate(velocidade * Vector3.up * Time.deltaTime, Space.World);
          } else if (mouseY >= top_limiar && mouseY <= Screen.height) { // top-left corner
            transform.Translate(velocidade * Vector3.left * Time.deltaTime, Space.World);
            transform.Translate(velocidade * Vector3.down * Time.deltaTime, Space.World);
          }
        } else if (mouseX >= right_limiar && mouseX <= Screen.width) { // right side of screens
            if (mouseY >= 0 && mouseY <= bottom_limiar) { // bottom-right corner
              transform.Translate(velocidade * Vector3.right * Time.deltaTime, Space.World);
              transform.Translate(velocidade * Vector3.up * Time.deltaTime, Space.World);
            } else if (mouseY >= top_limiar && mouseY <= Screen.height) { // top-right corner
              transform.Translate(velocidade * Vector3.right * Time.deltaTime, Space.World);
              transform.Translate(velocidade * Vector3.down * Time.deltaTime, Space.World);
            }
        }
    }
}
