namespace Game.S.Scripts.Interfaces.Movimentos
{
    using UnityEngine;

    public interface IMovimentos
    {
        public void Acao(Rigidbody2D rb2D, float force);
    }
}