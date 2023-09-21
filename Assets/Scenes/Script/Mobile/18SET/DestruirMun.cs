using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMun : MonoBehaviour
{
    public static int pontos = 0;
    void Start()
    {
        Destroy(gameObject,3f);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coleta)
    {
        if (coleta.gameObject.CompareTag("inimigo"))
        {
            pontos++;
            Destroy(gameObject);
        }
        if (coleta.gameObject.CompareTag("limite"))
        {
            Destroy(gameObject);
        }
    }
}
