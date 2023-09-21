using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaGame : MonoBehaviour
{
    private float TempoTotal = 60f;
    private float TempoAtual = 0f;
    private bool JogoAtivo;
    public Text tempoText, mensagemText, pontoText;
    public GameObject botaoRestart;

    
    void Start()
    {
        Time.timeScale = 1f;
        JogoAtivo = true;
        botaoRestart.SetActive(false);
    }
    void Update()
    {
        if (JogoAtivo)
        {
            TempoAtual += Time.deltaTime;
            if (TempoAtual >= TempoTotal)
            {
                JogoAtivo = false;
            }
            AtualizaTempo();
            pontoText.text = "Pontos: "+ DestruirMun.pontos.ToString("00");
            if (DestruirMun.pontos >= 10)
            {
                mensagemText.text = "PARABÉNS! VOCÊ VENCEU!";
                Time.timeScale = 0f;
                botaoRestart.SetActive(true);
            }
            if (APC.perdeu)
            {
                Time.timeScale = 0f;
                mensagemText.text = "VOCÊ PERDEU!";
                botaoRestart.SetActive(true);
            }
        }
        
        GameOver();
    }
    void AtualizaTempo()
    {
        float TempoRestante = TempoTotal - TempoAtual;
        tempoText.text = "Tempo: " + TempoRestante.ToString("00");
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("Mob-18SET");
        Time.timeScale = 1f;        
    }
    private void GameOver()
    {
        if (JogoAtivo == false)
        {
            Time.timeScale = 0f;
            mensagemText.text = "O TEMPO ACABOU!";
            botaoRestart.SetActive(true);
        }        
    }
}
