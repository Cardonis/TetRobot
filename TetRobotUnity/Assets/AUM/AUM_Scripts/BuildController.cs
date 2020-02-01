using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public GameObject currentPiece;

    List<GameObject> piecesComing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
    public void nextPiece()
    {

    }
}
