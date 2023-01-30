namespace Game.S.Scripts.MVC.Controladores
{
    using System.Linq;
    using UnityEngine;
    using Model;
    using View;

    public class ControladorIngredientes : MonoBehaviour
    {
        [SerializeField] [Tooltip("Tempo de esperar para gerar um novo ingrediente.")] private float timer;
        [SerializeField] [Tooltip("Referência para o ingrediente que será instânciado.")] private Ingrediente[] ingredientes;
        [SerializeField] [Tooltip("Referência para o pai do objeto spawnado.")] private ObjetoParaMovimentar objetoParaMovimentar;
        [SerializeField] [Tooltip("Posição que o objeto será instânciado.")] private Transform posicaoSpawn;

        public bool PodeInstanciarIngrediente {get; private set;}
        public Ingrediente IngredienteInstanciado {get; private set;}

        private void Start()
        {
            GerarIngrediente();
        }

        public void GerarIngredienteAposTempo()
        {
            PodeInstanciarIngrediente = false;
            this.ExecutarAcaoAposTempo(GerarIngrediente, timer);
        }
        private void GerarIngrediente()
        {
            var rdnIngrediente = ingredientes[Random.Range(0, ingredientes.Length)];
            var spawnTransform = objetoParaMovimentar.transform;
            var gerarIngrediente = false;
            PodeInstanciarIngrediente = true;

            if (ControladorPool.Instance.ingredientesQuePodemSerReaproveitados != null)
            {
                foreach (var ingrediente in ControladorPool.Instance.ingredientesQuePodemSerReaproveitados.Where(ingrediente => rdnIngrediente.TipoIngrediente == ingrediente.TipoIngrediente))
                {
                    ingrediente.transform.parent = spawnTransform;
                    ingrediente.transform.position = posicaoSpawn.position;
                    gerarIngrediente = true;
                    ControladorPool.Instance.ReaproveitarIngrediente(ingrediente);
                }
            }
            if (!gerarIngrediente)
            {
                IngredienteInstanciado = Instantiate(rdnIngrediente, spawnTransform);
                IngredienteInstanciado.transform.position = posicaoSpawn.position;
                ControladorPool.Instance.ingredientesInstanciadosNaoReaproveitados.Enqueue(IngredienteInstanciado);
            }
        }
        
        public void SoltarIngrediente()
        {
            var tr = IngredienteInstanciado.transform;
            
            tr.parent = null;
            IngredienteInstanciado.Rb2d.position = tr.position;
        }
    }  
}