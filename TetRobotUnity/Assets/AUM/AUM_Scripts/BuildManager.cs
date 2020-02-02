﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public float baseTimer;
    float timer;
    public bool timering = false;
    TextMeshProUGUI textTimer;

    public BuildController1 buildController1;
    public BuildController2 buildController2;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
        textTimer = GameObject.Find("TextTimer").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timering)
        {
            timer -= Time.deltaTime;

            textTimer.text = Mathf.Round(timer).ToString();
            
            if(timer < 0)
            {
                EndBuild();
            }
        }
    }
    
    public void StartTimer()
    {
        timering = true;
        timer = baseTimer;
    }

    public void EndBuild()
    {
        timering = false;
        GameObject.Find("GameManager").GetComponent<GameplayPhase>().inBuild = false;

        Destroy(buildController1.currentPiece);
        Destroy(buildController2.currentPiece);

        Debug.Log("Transitiooooooooooon");
        GameObject.Find("BuildPhase").SetActive(false);
    }
}
