namespace Game.S.Scripts.MVC.Controladores
{
    using UnityEngine;
    using Interfaces.Efeitos;
    using Enumeradores;
    using View;
    
    public class ControladorEfeito : MonoBehaviour
    {
        [SerializeField] private AplicarEfeito[] itensParaAplicarEfeito;

        private void Start()
        {
            foreach (var itemParaAplicarEfeito in itensParaAplicarEfeito)
                DefinirEfeito(itemParaAplicarEfeito);
        }
        private void DefinirEfeito(AplicarEfeito itemParaAplicarEfeito)
        {
            var gameObjectObjetoParaAplicarEfeito = itemParaAplicarEfeito.gameObject;
            
            itemParaAplicarEfeito.efeito = itemParaAplicarEfeito.tipoEfeito switch
            {
                TipoEfeito.Fade => gameObjectObjetoParaAplicarEfeito.AddComponent<Fade>(),
                _ => itemParaAplicarEfeito.efeito
            };
        }
    }
}