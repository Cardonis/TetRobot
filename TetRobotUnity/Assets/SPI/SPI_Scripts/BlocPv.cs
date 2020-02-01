using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocPv : MonoBehaviour
{
    public int maxPv, currentPv;
    private void Start()
    {
        currentPv = maxPv;
    }
    private void Update()
    {
        if (currentPv <= 0)
            Destroy(gameObject);
    }
}
