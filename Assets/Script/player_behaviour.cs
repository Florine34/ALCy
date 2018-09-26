using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_behaviour : MonoBehaviour {

    private bool canGrab = false;

    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D[] hit;
    public float distance = 1000000f;
    public LayerMask mask;
    public LineRenderer line;



	// Use this for initialization
	void Start () {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;

        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        line.SetPosition(0, transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            if (joint.enabled == true)
            {
                joint.enabled = false;
                line.enabled = false;
            }
            else
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //prend la position de la souris
                targetPos.z = 0;

                hit = Physics2D.RaycastAll(transform.position, targetPos - transform.position, distance, mask); //Lance un raycast dans la direction de la souris

                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].collider.name == "Crochet") //On test si la grappin à touché le crochet (CHANGER "YELLOW SQUARE" PAR LE NOM DU COLLIDER DU MODULE DE GAPPIN)
                    {
                        joint.connectedAnchor = hit[i].transform.position; //On définie le point auquel le grappin est accroché
                        joint.distance = Vector2.Distance(transform.position, hit[i].transform.position); //Sauvegarde la distance entre le joueur et le crochet

                        //dessine la line
                        line.SetPosition(0, transform.position);
                        line.SetPosition(1, hit[i].transform.position);
                        

                        canGrab = true;
                    }
                }

                if (hit.Length > 1 && canGrab==true)
                {
                    joint.enabled = true; //Grappin actif

                    line.enabled = true; //ligne active


                    canGrab = false;
                }
            }
        }

        if (Input.GetMouseButton(0) && joint.distance>1)
        {
            joint.distance -= 0.2f;
        }
	}
}
