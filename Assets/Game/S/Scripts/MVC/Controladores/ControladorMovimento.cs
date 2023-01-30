namespace Game.S.Scripts.MVC.Controladores
{
    using UnityEngine;
    using Interfaces.Movimentos;
    using Enumeradores;
    using View;
    
    public class ControladorMovimento : MonoBehaviour
    {
        [SerializeField] private ObjetoParaMovimentar[] objetosParaMovimentar;

        private void Start()
        {
            foreach (var objetoParaMovimentar in objetosParaMovimentar)
                DefinirTipoMovimento(objetoParaMovimentar);
        }
        private void DefinirTipoMovimento(ObjetoParaMovimentar obj)
        {
            obj.referenciaMovimento = obj.TipoMovimento switch
            {
                TipoMovimentos.MHS => obj.gameObject.AddComponent<Mhs>(),
                _ => obj.referenciaMovimento
            };
        }
        
        
    }
}