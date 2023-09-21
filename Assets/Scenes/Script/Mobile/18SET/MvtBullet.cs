using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtBullet : MonoBehaviour
{
    public float velo;
    void Start()
    {
        velo = 3f;
    }
    void Update()
    {
        transform.position += Vector3.up * velo * Time.deltaTime;
        if (transform.position.x > 3)
        {
            Destroy(gameObject);            
        }
        if (transform.position.y > 3 || transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
