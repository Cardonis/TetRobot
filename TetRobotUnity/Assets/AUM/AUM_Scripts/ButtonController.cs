using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.ParticleSystemJobs;

public class ButtonController : MonoBehaviour, ISelectHandler
{
    public int player;
    GameObject buildController;

    bool readyToPlace = false;
    bool thisBlocked = false;
    int numberOfBlocks = 0;

    public float distanceBetweenButtons;

    GameObject thisBloc;

    public GameObject leftButton;
    public GameObject upButton;
    public GameObject rightButton;
    public GameObject downButton;

    ParticleSystem stars;

    // Start is called before the first frame update
    void Start()
    {
        stars = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

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

        CheckBlocs();
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToPlace == true)
        {
            Button b = GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 0.5f);
            b.colors = cb;
        }
        else
        {
            Button b = GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 0.05f);
            b.colors = cb;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (player == 1)
        {
            buildController.GetComponent<BuildController1>().currentPiece.transform.position = transform.position;
        }
        else if (player == 2)
        {
            buildController.GetComponent<BuildController2>().currentPiece.transform.position = transform.position;
        }

    }

    public void BlockPosed()
    {
        if (player == 1)
        {
            bool stop = true;

            GameObject[] buttons1 = GameObject.FindGameObjectsWithTag("Button1");
            GameObject[] blocs = GameObject.FindGameObjectsWithTag("Bloc");

            foreach (GameObject button1 in buttons1)
            {
                foreach (GameObject bloc in blocs)
                {
                    if (bloc.transform.position.x >= button1.transform.position.x - 0.2f && bloc.transform.position.x <= button1.transform.position.x + 0.2f
                        && bloc.transform.position.y >= button1.transform.position.y - 0.2f && bloc.transform.position.y <= button1.transform.position.y + 0.2f)
                    {
                        button1.GetComponent<ButtonController>().thisBloc = bloc;
                        button1.GetComponent<ButtonController>().thisBlocked = true;
                        button1.GetComponent<ButtonController>().numberOfBlocks++;
                    }

                }
            }

            foreach (GameObject button1 in buttons1)
            {
                if (button1.GetComponent<ButtonController>().readyToPlace == true && button1.GetComponent<ButtonController>().thisBloc != null)
                {
                    stop = false;
                    break;
                }

            }

            foreach (GameObject button1 in buttons1)
            {
                if (button1.GetComponent<ButtonController>().numberOfBlocks > 1)
                {
                    stop = true;
                    break;
                }
                    
            }

            if (stop == false)
            {
                foreach (GameObject button1 in buttons1)
                {
                    button1.GetComponent<ButtonController>().CheckBlocs();
                }

                buildController.GetComponent<BuildController1>().piecesComing.RemoveAt(0);
                buildController.GetComponent<BuildController1>().currentPiece = Instantiate(buildController.GetComponent<BuildController1>().piecesComing[0], GameObject.Find("Ship1").transform);

                buildController.GetComponent<BuildController1>().currentPiece.transform.position = transform.position;
                buildController.GetComponent<BuildController1>().piecesComing.Add(buildController.GetComponent<BuildController1>().pieceGenerator.GetComponent<PieceGenerator>().GivePiece());

                buildController.GetComponent<BuildController1>().UpdatePiecesComing();

                stars.Play();
            }
            
                foreach (GameObject button1 in buttons1)
                {
                    if (button1.GetComponent<ButtonController>().thisBlocked == true)
                    {
                        button1.GetComponent<ButtonController>().thisBloc = null;
                        button1.GetComponent<ButtonController>().thisBlocked = false;
                    }

                

                    button1.GetComponent<ButtonController>().numberOfBlocks = 0;

                }
            

        }

        else if (player == 2)
        {
            bool stop = true;

            GameObject[] buttons2 = GameObject.FindGameObjectsWithTag("Button2");
            GameObject[] blocs = GameObject.FindGameObjectsWithTag("Bloc");

            foreach (GameObject button2 in buttons2)
            {
                foreach (GameObject bloc in blocs)
                {
                    if (bloc.transform.position.x >= button2.transform.position.x - 0.2f && bloc.transform.position.x <= button2.transform.position.x + 0.2f
                        && bloc.transform.position.y >= button2.transform.position.y - 0.2f && bloc.transform.position.y <= button2.transform.position.y + 0.2f)
                    {
                        button2.GetComponent<ButtonController>().thisBloc = bloc;
                        button2.GetComponent<ButtonController>().thisBlocked = true;
                        button2.GetComponent<ButtonController>().numberOfBlocks++;
                    }

                }
            }

            foreach (GameObject button2 in buttons2)
            {
                if (button2.GetComponent<ButtonController>().readyToPlace == true && button2.GetComponent<ButtonController>().thisBloc != null)
                {
                    stop = false;
                    break;
                }

            }

            foreach (GameObject button2 in buttons2)
            {
                if (button2.GetComponent<ButtonController>().numberOfBlocks > 1)
                {
                    stop = true;
                    break;
                }

            }

            if (stop == false)
            {
                foreach (GameObject button2 in buttons2)
                {
                    button2.GetComponent<ButtonController>().CheckBlocs();
                }

                buildController.GetComponent<BuildController2>().piecesComing.RemoveAt(0);
                buildController.GetComponent<BuildController2>().currentPiece = Instantiate(buildController.GetComponent<BuildController2>().piecesComing[0], GameObject.Find("Ship2").transform);
                                                            
                buildController.GetComponent<BuildController2>().currentPiece.transform.position = transform.position;
                buildController.GetComponent<BuildController2>().piecesComing.Add(buildController.GetComponent<BuildController2>().pieceGenerator.GetComponent<PieceGenerator>().GivePiece());
                                                            
                buildController.GetComponent<BuildController2>().UpdatePiecesComing();

                stars.Play();
            }

            foreach (GameObject button2 in buttons2)
            {
                if (button2.GetComponent<ButtonController>().thisBlocked == true)
                {
                    button2.GetComponent<ButtonController>().thisBloc = null;
                    button2.GetComponent<ButtonController>().thisBlocked = false;
                }



                button2.GetComponent<ButtonController>().numberOfBlocks = 0;

            }


        }
    }

    public void CheckBlocs()
    {
        GameObject[] blocs = GameObject.FindGameObjectsWithTag("Bloc");

        foreach(GameObject bloc in blocs)
        {
            if(bloc.transform.position.x >= transform.position.x - 0.2f && bloc.transform.position.x <= transform.position.x + 0.2f 
                && bloc.transform.position.y >= transform.position.y - 0.2f && bloc.transform.position.y <= transform.position.y + 0.2f)
            {
                thisBloc = bloc;
            }

        }

        readyToPlace = false;

        if (thisBloc == null)
        {
            if (leftButton != null)
                if (leftButton.GetComponent<ButtonController>().thisBloc != null)
                {
                    readyToPlace = true;
                }

            if (rightButton != null)
                if (rightButton.GetComponent<ButtonController>().thisBloc != null)
                {
                    readyToPlace = true;
                }

            if (upButton != null)
                if (upButton.GetComponent<ButtonController>().thisBloc != null)
                {
                    readyToPlace = true;
                }

            if (downButton != null)
                if (downButton.GetComponent<ButtonController>().thisBloc != null)
                {
                    readyToPlace = true;
                }

        }

    }

}
