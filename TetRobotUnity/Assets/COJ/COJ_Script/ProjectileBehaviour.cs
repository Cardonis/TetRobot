using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Rigidbody2D bullet;
    public float speed;
    public Vector2 bulletDir;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody2D>();
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
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bloc"))
        {
            collision.GetComponent<BlocHit>().DamageTaken();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
