using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGestion : MonoBehaviour
{
    public float shipMass;
    public int piecesAdded;
    public float pieceMass;

    //refaire pareil pour le nombre de bloc blindés

    private Rigidbody2D shipRB;

    private void Start()
    {
        shipRB = GetComponent<Rigidbody2D>();
        shipMass = shipRB.mass;
    }
    private void Update()
    {
       if (gameObject.transform.childCount > piecesAdded)
       {
            piecesAdded++;
            shipMass += pieceMass;
            shipRB.mass = shipMass;
       }
       if (gameObject.transform.childCount < piecesAdded)
        {
            piecesAdded--;
            shipMass -= pieceMass;
            shipRB.mass = shipMass;
        }
    }
}
