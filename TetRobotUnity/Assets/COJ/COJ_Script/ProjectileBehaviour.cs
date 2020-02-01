using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Rigidbody2D bullet;
    public float speed;
    Vector2 bulletDir;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody2D>();
        if (gameObject.CompareTag("P1"))
        {
            player = GameObject.Find("Player1");
            bulletDir = player.transform.up;
            Debug.Log(bulletDir);
        }
        else if(gameObject.CompareTag("P2"))
        {
            player = GameObject.Find("Player2");
            bulletDir = player.transform.up;
            Debug.Log(bulletDir);
        }
        StartCoroutine(Destroy());
     
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }


    /// <summary>
    /// Bullet move forward
    /// </summary>
    void MoveForward()
    {
        bullet.velocity = bulletDir * speed;
        Debug.Log("allo");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
