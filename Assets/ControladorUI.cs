using System;
using System.Collections;
using Game.S.Scripts.MVC.Model;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    [SerializeField] [Tooltip("Referência para o painel que impede input de apressadinhos.")] private GameObject pnlContraInput;
    [SerializeField] [Tooltip("Referência para o painel de game over.")] private GameObject pnlGameover;
    [SerializeField] [Tooltip("Referência para o texto dos pontos durante a gameplay.")] private Text txtPontos;
    [SerializeField] [Tooltip("Referência para o texto do timer.")] private Text txtTimer;
    [SerializeField] [Tooltip("Referência para o texto dos pontos da tela de game over.")] private Text txtPontosGameOver;
    [SerializeField] [Tooltip("Referência para o texto do hgihscore na tela de game over.")] private Text txtHighscore;
    [SerializeField] [Tooltip("Referência para a imagem de new highscore.")] private Image imgNew;
    [SerializeField] [Tooltip("Referência para a imagem do timer.")] private Image imgTimer;

    private void Start()
    {
        this.ExecutarAcaoAposTempo(StartExecutarTimer, 3);
    }

    public void GameOver()
    {
        var tmpPontos = Convert.ToInt32(txtPontos.text);
        pnlGameover.SetActive(true);

        if (tmpPontos > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", tmpPontos);
            imgNew.gameObject.SetActive(true);
        }

        StartCoroutine(AtualizarTexto(tmpPontos, txtPontosGameOver));
        StartCoroutine(AtualizarTexto(PlayerPrefs.GetInt("Highscore"), txtHighscore));
    }
    public void AtualizarPontos()
    {
        txtPontos.text = (Convert.ToInt32(txtPontos.text) + 1).ToString();
    }
    private void StartExecutarTimer()
    {
        StartCoroutine(ExecutarTimer());
    }
    private IEnumerator ExecutarTimer()
    {
        var cor = txtTimer.color;
        imgTimer.gameObject.SetActive(true);
        for (var i = 3; i > 0; i--)
        {
            txtTimer.text = i.ToString();
            for (int j = 0, x = 200; j < x; j++)
            {
                txtTimer.color = new Color(cor.r, cor.g, cor.b, (255f - j) / 255f);
                yield return new WaitForSeconds(0.5f / x * Time.deltaTime);
            }
        }
        imgTimer.gameObject.SetActive(false); 
        pnlContraInput.SetActive(false);
    }
    private IEnumerator AtualizarTexto(int index, Text texto)
    {
        for (var i = 0; i < index; i++)
        {
            texto.text = (Convert.ToInt32(texto.text) + 1).ToString(); 
            yield return new WaitForSeconds(0.15f);
        }
    }
}