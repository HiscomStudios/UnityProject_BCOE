namespace Game.S.Scripts.MVC.Controladores
{
    using System.Collections.Generic;
    using UnityEngine;
    using View;
    
    public class ControladorPool : MonoBehaviour
    {
        public Queue<Ingrediente> ingredientesInstanciadosNaoReaproveitados;
        public List<Ingrediente> ingredientesQuePodemSerReaproveitados;
        private Camera _main;

        private void Awake()
        {
            _main = Camera.main;
            
            ingredientesInstanciadosNaoReaproveitados = new Queue<Ingrediente>();
            ingredientesQuePodemSerReaproveitados = new List<Ingrediente>();
        }

        public void VerificarSeIngredientePodeSerReaproveitado()
        {
            if (!(_main.WorldToViewportPoint(ingredientesInstanciadosNaoReaproveitados.Peek().transform.position).y < 0)) return;
            ingredientesQuePodemSerReaproveitados.Add(ingredientesInstanciadosNaoReaproveitados.Peek());
            ingredientesInstanciadosNaoReaproveitados.Dequeue();
        }
        public void ReaproveitarIngrediente(Ingrediente ingrediente)
        {
            ingredientesQuePodemSerReaproveitados.Remove(ingrediente);
            ingredientesInstanciadosNaoReaproveitados.Enqueue(ingrediente);
        }

        #region Singleton
        
        private static ControladorPool _instance;
        public static ControladorPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    var provider = Instantiate(Resources.Load("ControladorPool") as GameObject).GetComponent<ControladorPool>();
                    provider.name = "@ControladorPool";
                    DontDestroyOnLoad(provider.gameObject);
                    _instance = provider;
                }
                return _instance;
            }
        }
        
        #endregion
    }
}