namespace Game.S.Scripts.MVC.Controladores
{
    using UnityEngine;
    
    public class ControladorFase : MonoBehaviour
    {
        [SerializeField] [Tooltip("Os objetos que sofreram um aumento em sua posição Y.")] private GameObject[] objetosParaSubir;
        [SerializeField] [Tooltip("Referência para o controlador de ingredientes.")] private ControladorIngredientes controladorIngredientes;

        public void SubirObjetos()
        {
            foreach (var t in objetosParaSubir)
                t.transform.Translate(0, controladorIngredientes.IngredienteInstanciado.GetComponent<BoxCollider2D>().size.y , 0);
            
            ControladorPool.Instance.VerificarSeIngredientePodeSerReaproveitado();
        }
    }
}