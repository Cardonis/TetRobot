using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, ISelectHandler
{
    public int player;
    GameObject buildController;
    GameObject currentPiece;

    // Start is called before the first frame update
    void Start()
    {
        if(player == 1)
        {
            buildController = GameObject.Find("BuildController1");
            currentPiece = buildController.GetComponent<BuildController1>().currentPiece;
        }
        if (player == 2)
        {
            buildController = GameObject.Find("BuildController2");
            //currentPiece = buildController.GetComponent<BuildController2>().currentPiece;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (player == 1)
        {
            buildController.GetComponent<BuildController1>().currentPiece.transform.position = transform.position;
        }
        
    }

    public void blockPosed()
    {
        if (player == 1)
        {

            buildController.GetComponent<BuildController1>().currentPiece.transform.position = transform.position;

        }
    }

}
