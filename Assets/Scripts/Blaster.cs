using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {

    public GameObject blaster, barrel;
    public GameObject bullet;
    public float power;
    public float ReloadingTime = 1f;
    public bool isReloaded;


    void Start()
    {
        isReloaded = true;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Mouse0) && isReloaded)
        {
            Shoot();
            isReloaded = false;
            Invoke("Reload", ReloadingTime);
        }*/
    }

    void Shoot()
    {
        GameObject tmpBullet;
        tmpBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);

        Rigidbody2D rigBullet = tmpBullet.GetComponent<Rigidbody2D>();
        rigBullet.AddRelativeForce(new Vector2(power * Time.deltaTime * transform.localScale.x, rigBullet.velocity.y));
    }

    public void MobileShoot()
    {
        if(isReloaded)
        {
            Shoot();
            isReloaded = false;
            Invoke("Reload", ReloadingTime);
        }
    }

    void Reload()
    {
        isReloaded = true;
    }
}
