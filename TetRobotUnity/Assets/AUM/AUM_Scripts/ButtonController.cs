using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, ISelectHandler
{
    public int player;
    GameObject buildController;

    GameObject thisBloc;
    GameObject leftBloc;
    GameObject upBloc;
    GameObject rightBloc;
    GameObject downBloc;

    // Start is called before the first frame update
    void Start()
    {
        if(player == 1)
        {
            buildController = GameObject.Find("BuildController1");
            //currentPiece = buildController.GetComponent<BuildController1>().currentPiece;
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

    public void BlockPosed()
    {
        if (player == 1)
        {
            buildController.GetComponent<BuildController1>().piecesComing.RemoveAt(0);
            buildController.GetComponent<BuildController1>().currentPiece = Instantiate(buildController.GetComponent<BuildController1>().piecesComing[0], GameObject.Find("Ship1").transform);

            buildController.GetComponent<BuildController1>().currentPiece.transform.position = transform.position;
            buildController.GetComponent<BuildController1>().piecesComing.Add(GameObject.Find("PieceGenerator").GetComponent<PieceGenerator>().GivePiece());

            GameObject[] buttons1 = GameObject.FindGameObjectsWithTag("Button1");

            foreach(GameObject button1 in buttons1)
            {
                button1.GetComponent<ButtonController>().CheckBlocs();
            }
        }
    }

    public void CheckBlocs()
    {
        
    }

}
