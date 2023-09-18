using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public AmmoType ammoType;
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1.0f;

    private bool reloading;
    private float reloadTimer;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        //Reloading();
    }

    private void Reloading()
    {
        if (reloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                currentAmmo = maxAmmo;
                reloading = false;
            }
        }
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !reloading)
        {
            currentAmmo--;
            GameObject bulletPrefab = bulletPrefabs[(int)ammoType];
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // mo¿esz tutaj dodaæ kod, który bêdzie okreœlaæ, jak poruszaæ siê bêdzie pocisk
        }
        else if (currentAmmo == 0)
        {
            reloading = true;
            reloadTimer = 0.0f;
        }
    }
}