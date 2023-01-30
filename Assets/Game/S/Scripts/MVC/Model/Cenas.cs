namespace Game.S.Scripts.MVC.Model
{
    using UnityEngine.SceneManagement;
    
    public class Cenas
    {
        public static int RetornarProximaCena()
        {
            var cenaAtual = SceneManager.GetActiveScene();
            return cenaAtual.buildIndex + 1 == SceneManager.sceneCountInBuildSettings ? 0 : cenaAtual.buildIndex + 1;
        }
    }
}