using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarInimigos : MonoBehaviour
{
    private float minX, maxX, nextObj;
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private float minDist, maxDist, tempoCriar;
    void Start()
    {
        nextObj = Time.time;
        AjustarMinMaxX();
    }
    void Update()
    {
        Criar();
    }
    private void AjustarMinMaxX()
    {
        Vector3 limites = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f));
        minX = -limites.x + minDist;
        maxX = limites.x + maxDist;
    }
    private void Criar()
    {
        if (Time.time > nextObj)
        {
            Vector2 position = new Vector2(Random.Range(-10f, 8f), transform.position.y);
            Instantiate(inimigos[Random.Range(0, inimigos.Length)], new Vector2(position.x, position.y), Quaternion.Euler(0f, 0f, 90f));
            nextObj = Time.time + tempoCriar;
        }
    }
}
