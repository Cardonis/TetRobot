﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    public float rotationSpeed;

    public GameObject bulletPrefab;
    bool canShoot = true;

    public string fire, horizontalAxe, verticalAxe, rotateRight, rotateLeft;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        if (Input.GetButton(fire))
        {
            if(canShoot == true)
            {
                canShoot = false;
               // StartCoroutine(Shoot());
            }
        }
    }

    /// <summary>
    /// Make the ship move around with the left joystick
    /// </summary>
    void Move()
    {
        Vector2 playerDir = new Vector2(Input.GetAxis(horizontalAxe), Input.GetAxis(verticalAxe));
        player.AddForce(playerDir * speed * Time.deltaTime);
    }

    /// <summary>
    /// Make the ship rotate around with the LT or RT input
    /// </summary>
    void Rotate()
    {

        float zAngle;
        if(Input.GetAxis(rotateRight) > 0.5f)
        {
            zAngle = 1;
        }
        else if(Input.GetAxis(rotateLeft) > 0.5f)
        {
            zAngle = -1;
        }
        else
        {
            zAngle = 0;
        }
        gameObject.transform.Rotate(0, 0, zAngle * rotationSpeed * Time.deltaTime,Space.World);

    }

    /*IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }*/
}
