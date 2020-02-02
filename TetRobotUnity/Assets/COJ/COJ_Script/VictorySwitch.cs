using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySwitch : MonoBehaviour
{
    private void OnDisable()
    {

        if (gameObject.CompareTag("Pilote1"))
        {
            SceneManager.LoadScene(3);
        }
        else if (gameObject.CompareTag("Pilote2"))
        {
            SceneManager.LoadScene(4);
        }
    }
}
