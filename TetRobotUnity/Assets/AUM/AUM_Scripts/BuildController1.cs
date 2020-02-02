using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController1 : BuildController
{
    float rotateTimer;
    float bTimer;

    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();

        currentPiece = Instantiate(piecesComing[0], GameObject.Find("Ship1").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("LT_Player1") > 0 && rotateTimer < 0)
        {
            Rotate("Left");
            rotateTimer = 0.5f;
        }
        else
        {
            rotateTimer -= Time.deltaTime;
        }

        if (Input.GetAxis("RT_Player1") > 0 && rotateTimer < 0)
        {
            Rotate("Right");
            rotateTimer = 0.5f;
        }
        else
        {
            rotateTimer -= Time.deltaTime;
        }

        if(Input.GetButton("B_Player1") && bTimer < 0)
        {
            NextPiece();
            bTimer = 0.5f;
        }
        else
        {
            bTimer -= Time.deltaTime;
        }

    }
}
