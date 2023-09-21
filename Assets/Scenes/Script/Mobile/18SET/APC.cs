using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APC : MonoBehaviour
{
    public float velo;
    public static bool perdeu;
    void Start()
    {
        perdeu = false;
    }
    void Update()
    {
        transform.position += Vector3.down * velo * Time.deltaTime;        
    }
    private void OnTriggerEnter2D(Collider2D coleta)
    {
        if (coleta.gameObject.CompareTag("municao"))
        {
            Destroy(gameObject);
        }
        if (coleta.gameObject.CompareTag("limite"))
        {
            perdeu=true;
            Destroy(gameObject);
        }
    }
}
