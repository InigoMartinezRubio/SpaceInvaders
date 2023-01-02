using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float timeInShots;
    public float nextShot = -1;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        nextShot = Random.Range(1, 3.0f);
        timeInShots = Random.Range(3, 6.5f);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + timeInShots;
        }
    }
}
