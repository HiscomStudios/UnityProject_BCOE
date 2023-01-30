using System;

namespace Game.S.Scripts.MVC.Controladores.Menu
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;
    using Model;

    public class ControladorOpcoes : MonoBehaviour
    {
        [SerializeField] private GameObject[] botoesMusica;
        [SerializeField] private GameObject[] botoesSons;

        private void Start()
        {
            ConfiguracaoInicial(Convert.ToBoolean(PlayerPrefs.GetInt("Musicas")), botoesMusica);
            ConfiguracaoInicial(Convert.ToBoolean(PlayerPrefs.GetInt("Sons")), botoesSons);
        }

        public void AtivarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", 0);
            AlterarSistema(group.name, true);
        }
        public void DesativarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", -80);
            AlterarSistema(group.name, false);
        }
        private void AlterarSistema(string nome, bool act)
        {
            PlayerPrefs.SetInt(nome, Convert.ToInt32(!act));
        }
        private void ConfiguracaoInicial(bool t, IReadOnlyList<GameObject> imagens)
        {
            foreach (var imagem in imagens)
            {
                imagem.SetActive(t);
                t = !t;
            }
        }
    }
}