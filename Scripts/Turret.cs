using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Structures {
    public int arc;
    public int radius;
    public int angle;
    public float range = .7f;

    private float timeout = .250f;

    public enum TurretType { EXPLODE=0, DEPART, ARRIVE, FUZZY, DEAFEN };

    public TurretType type;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
            
	}

    void OnMouseDown()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("humano"))
        {
            

            if (Vector3.Distance(go.transform.position, transform.position) < radius)
            {

                Vector3 relative = transform.InverseTransformPoint(go.transform.position);
                float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

                if (targetAngle > angle - (arc / 2) && targetAngle < angle + (arc / 2))
                {
                    

                    switch (GetComponent<Turret>().type)
                    {
                        case Turret.TurretType.EXPLODE:
                            go.SendMessage("Morra", 1f);
                            break;
                        case Turret.TurretType.ARRIVE: go.SendMessage("ApplyTarget", targetAngle); break;
                        case Turret.TurretType.DEAFEN: go.SendMessage("Hear"); break;
                        case Turret.TurretType.DEPART: go.SendMessage("ReplyTarget", targetAngle); break;
                        case Turret.TurretType.FUZZY: go.SendMessage("Retarda"); break;


                    }

                }
            }
        }
    }


}
