using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorBehaviour : MonoBehaviour
{
    Animator reactorAnim;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

        reactorAnim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
