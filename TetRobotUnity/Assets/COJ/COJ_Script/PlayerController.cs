using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// Make the ship move around with the left joystick
    /// </summary>
    void Move()
    {
        Vector2 playerDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        player.AddForce(playerDir * speed * Time.deltaTime);
    }

    /// <summary>
    /// Make the ship rotate around with the LT or RT input
    /// </summary>
    void Rotate()
    {
        float turn;

    }
}
