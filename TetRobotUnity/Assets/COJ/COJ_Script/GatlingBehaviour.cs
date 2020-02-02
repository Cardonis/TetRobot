using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBehaviour : MonoBehaviour
{
    public ProjectileBehaviour bulletBehaviour;
    public GameObject bulletPrefab;
    bool canShoot = true;
    public string fire;
    public Transform firePoint;
    Animator fireAnim;

    public GameObject gM;


    // Start is called before the first frame update
    void Start()
    {
        firePoint = gameObject.transform.GetChild(0);
        fireAnim = gameObject.GetComponent<Animator>();

        gM = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //if (gM.GetComponent<GameplayPhase>().inBuild == false)
        //{
            if (Input.GetButton(fire))
            {
                if (canShoot == true)
                {
                    canShoot = false;
                    StartCoroutine(Shoot());
                    fireAnim.SetBool("isShooting", true);
                }
            }
            else
            {
                fireAnim.SetBool("isShooting", false);
            }
        //}
       
    }

    /// <summary>
    /// Tire une balle depuis la gatling
    /// </summary>
    /// <returns></returns>
    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletBehaviour = bullet.GetComponent<ProjectileBehaviour>();
        bulletBehaviour.bulletDir = gameObject.transform.up;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
