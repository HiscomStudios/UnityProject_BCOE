namespace Game.S.Scripts.MVC.Controladores
{
    using UnityEngine;
    using Model;

    public class ControladorInicial : MonoBehaviour
    {
        [SerializeField] private GameObject[] objetosParaInstanciarNaPrimeiraVez;

        private void Start()
        {
            InstanciarObjetos();
        }
        private void InstanciarObjetos()
        {
            for (var i = 0; i < objetosParaInstanciarNaPrimeiraVez.Length; i++)
                if (objetosParaInstanciarNaPrimeiraVez[i] != Objetos.objetosParaNaoDestruir[i])
                    Objetos.objetosParaNaoDestruir.Add(objetosParaInstanciarNaPrimeiraVez[i]);
        }
    }
}