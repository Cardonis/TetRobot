using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    bool canShoot = true;
    public string fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(fire))
        {
            if(canShoot == true)
            {
                canShoot = false;
                StartCoroutine(Shoot());
            }

        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
