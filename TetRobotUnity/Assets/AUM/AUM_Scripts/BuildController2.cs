using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController2 : BuildController
{
    float rotateTimer;
    float bTimer;

    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("LT_Player2") > 0 && rotateTimer < 0)
        {
            Rotate("Left");
            rotateTimer = 0.5f;
        }
        else
        {
            rotateTimer -= Time.deltaTime;
        }

        if (Input.GetAxis("RT_Player2") > 0 && rotateTimer < 0)
        {
            Rotate("Right");
            rotateTimer = 0.5f;
        }
        else
        {
            rotateTimer -= Time.deltaTime;
        }

        if (Input.GetButton("B_Player2") && bTimer < 0)
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
