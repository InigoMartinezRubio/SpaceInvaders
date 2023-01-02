using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Create a clone of the projectile's prefab during gameplay
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
