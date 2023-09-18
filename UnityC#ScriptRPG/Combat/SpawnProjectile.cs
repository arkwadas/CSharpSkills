using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class SpawnProjectile : MonoBehaviour
    {

        public GameObject bullet;
        public Transform firePoint;


        public void Fire()
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}

