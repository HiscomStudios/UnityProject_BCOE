namespace Game.S.Scripts.MVC.Controladores
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Model;
    
    public class ControladorCena : MonoBehaviour
    {
        [SerializeField] private float temporizador;
        
        private void Start()
        {
            this.ExecutarAcaoAposTempo(CarregarCena, temporizador, false);
        }
        public void CarregarCena(bool destruir)
        {
            SceneManager.LoadScene(Cenas.RetornarProximaCena(), LoadSceneMode.Single);

            if (destruir) return;
            foreach (var objeto in Objetos.objetosParaNaoDestruir)
                DontDestroyOnLoad(objeto);
        }
    }
}