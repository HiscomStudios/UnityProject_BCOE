namespace Game.S.Scripts.MVC.View
{
    using UnityEngine;
    using Interfaces.Efeitos;
    using Model;
    using Enumeradores;
    
    public class AplicarEfeito : MonoBehaviour
    {
        public IEfeitos efeito;
        public TipoEfeito tipoEfeito;
        private CanvasGroup canvas;
        
        private void Awake()
        {
            canvas = GetComponent<CanvasGroup>();
        }
        public void Start()
        {
            this.ExecutarAcaoAposTempo(efeito.Acao, 1, canvas);
            this.ExecutarAcaoAposTempo(efeito.Acao, 4, canvas);
        }
    }
}