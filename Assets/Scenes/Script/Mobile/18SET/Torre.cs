using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    [SerializeField] private Transform cano;
    [SerializeField] private Rigidbody2D bala;
    private float veloBala, veloRotacao;
    private Touch umToque, moveToque, fogoToque;
    void Start()
    {
        veloBala = 300f;
        veloRotacao = 0.1f;
    }

    void Update()
    {
        if(Input.touchCount>0)
        {
            if (Input.touchCount == 1)
            {
                umToque = Input.GetTouch(0);
                if (umToque.position.x < Screen.width / 2)
                {
                    if (umToque.phase == TouchPhase.Moved)
                    {
                        transform.Rotate(0f, 0f, -umToque.deltaPosition.x * veloRotacao);
                    }
                }
                else
                {
                    if(umToque.phase==TouchPhase.Began)
                    {
                        var novaBala = Instantiate(bala, cano.position, cano.rotation);
                        novaBala.AddForce(cano.up * veloBala);
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(1).position.x > Screen.width / 2)
                {
                    moveToque = Input.GetTouch(0);
                    fogoToque = Input.GetTouch(1);
                }
                if (Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(1).position.x < Screen.width / 2)
                {
                    moveToque = Input.GetTouch(1);
                    fogoToque = Input.GetTouch(0);                    
                }
                if (moveToque.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, 0f, -moveToque.deltaPosition.x * veloRotacao);
                }               
                if (fogoToque.phase == TouchPhase.Began)
                {
                    var novaBala = Instantiate(bala, cano.position, cano.rotation);
                    novaBala.AddForce(cano.up * veloBala);
                }            
            }
        }        
    }
}
