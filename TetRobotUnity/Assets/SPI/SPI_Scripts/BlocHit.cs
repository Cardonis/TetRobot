using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocHit : MonoBehaviour
{
    public void DamageTaken()
    {
        gameObject.transform.GetComponentInParent<BlocPv>().currentPv--;
    }
}
