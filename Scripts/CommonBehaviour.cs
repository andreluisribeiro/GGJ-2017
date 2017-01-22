using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBehaviour : MonoBehaviour {
    public bool canRetards = true;
    public bool canHear = true;
    public float angle;
    
    public Animator a;
    public RuntimeAnimatorController homem, mulher;

    public float lastAngle;
    public float velocidade;
    public float strength;
    public float health;

    protected void SetupAnimator()
    {
        a = GetComponent<Animator>();
        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = Random.Range(0, 10) > 5 ? homem : mulher;
    }

    protected void Move () {
        // a.GetCurrentAnimatorStateInfo.name
        Debug.Log(angle);
        if(lastAngle != angle)
        {
            if (angle > 45 && angle < 135 || angle < -180 && angle > -45) a.SetTrigger("tras");
            else if (angle > 135 && angle < 225) a.SetTrigger("esquerda");
            else if (angle > 225 && angle < 315) a.SetTrigger("frente");
            else if (angle > 315 && angle < 360 || angle >= 0 && angle <= 45 || angle <= 0 && angle >= -45) a.SetTrigger("direita");
            lastAngle = angle;
        }

        transform.Translate(new Vector3((float)Mathf.Cos(angle * Mathf.Deg2Rad) * velocidade * Time.deltaTime, (float)Mathf.Sin(angle * Mathf.Deg2Rad) * velocidade * Time.deltaTime, 0));
    }

    public void AntiMove()
    {
        transform.Translate(new Vector3((float)Mathf.Cos((180 - 2 * angle) * Mathf.Deg2Rad) * 30 * -Time.deltaTime,
                                            (float)Mathf.Sin((180 - 2 * angle) * Mathf.Deg2Rad) * 30 * Time.deltaTime),0);
    }

    protected void ApplyTarget(float o)
    {
        
        lastAngle = angle;
        Debug.Log(o);
        if (canHear)
        {
            angle = 180 - 2 * o;
        }
    }

    protected void ReplyTarget(float o)
    {
        lastAngle = angle;
        if (canHear)
            angle = o;
    }

    void canRetardsAgain()
    {
        canRetards = true;
    }

    void Retarda()
    {
        if (canHear && canRetards)
        {
            canRetards = false;
            Invoke("canRetardsAgain", 5f);
            angle = Random.Range(0, 359);
        }
    }

    void canHearAgain()
    {
        canHear = true;
    }

    void Hear()
    {
        if (canRetards)
        {
            canHear = false;
            Invoke("canHearAgain", 5f);

        }
    }

    void Morra(float hp)
    {
        Debug.Log("...");
        this.health -= hp;
        if(this.health <= 0)
            Destroy(this.gameObject);
    }
}
