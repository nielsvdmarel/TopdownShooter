using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public Projectile projectile;
    public float bulletSpeed;
    public Transform muzzle;
    public float shootRate;

    private float nextFireTime;

    void Start()
    {
        nextFireTime = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time >= nextFireTime))
        {

            Shoot();

        }

    }

    public void Shoot()
    {
        Projectile bullet = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
        bullet.SetSpeed(bulletSpeed);
        nextFireTime = Time.time + shootRate;
    }



}


