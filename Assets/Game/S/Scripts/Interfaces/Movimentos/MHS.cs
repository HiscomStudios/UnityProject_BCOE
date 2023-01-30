namespace Game.S.Scripts.Interfaces.Movimentos
{
    using UnityEngine;

    public class Mhs : MonoBehaviour, IMovimentos
    {
        public void Acao(Rigidbody2D rb2D, float force)
        {
            rb2D.rotation = force;
        }
    }
}