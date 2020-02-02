using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public GameObject currentPiece;

    public List<GameObject> piecesComing;

    public List<GameObject> piecesComingPlaceurs;

    public GameObject pieceGenerator;

    // Start is called before the first frame update
    virtual public void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            piecesComing.Add(pieceGenerator.GetComponent<PieceGenerator>().GivePiece());
        }

        

        for (int i = 0; i < 5; i++)
        {
            Instantiate(piecesComing[i], piecesComingPlaceurs[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPiece()
    {
        piecesComing.RemoveAt(0);

        Vector2 position = currentPiece.transform.position;

        Destroy(currentPiece);


        currentPiece = Instantiate(piecesComing[0], GameObject.Find("Ship1").transform);

        currentPiece.transform.position = position;
        piecesComing.Add(pieceGenerator.GetComponent<PieceGenerator>().GivePiece());

        UpdatePiecesComing();        
        
    }

    public void Rotate(string direction)
    {
        float angle = 0;

        switch(direction)
        {
            case "Left":
                angle = -90f;
                break;

            case "Right":
                angle = 90f;
                break;
        }

        //currentPiece.transform.rotation = new Quaternion(currentPiece.transform.rotation.x, currentPiece.transform.rotation.y, currentPiece.transform.rotation.z + angle, currentPiece.transform.rotation.w);

        currentPiece.transform.eulerAngles += Vector3.forward * angle;
    }

    public void UpdatePiecesComing()
    {
        for(int i = 0; i < 5; i++)
        {
            Destroy(piecesComingPlaceurs[i].transform.GetChild(0).gameObject);
            Instantiate(piecesComing[i], piecesComingPlaceurs[i].transform);
        }
        
    }


}
