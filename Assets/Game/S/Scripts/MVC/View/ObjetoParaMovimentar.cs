namespace Game.S.Scripts.MVC.View
{
    using UnityEngine;
    using Enumeradores;
    using Interfaces.Movimentos;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class ObjetoParaMovimentar : MonoBehaviour
    {
        [SerializeField] [Tooltip("O ângulo máximo de abertura do movimento pendular.")] private float movimentoMaximo;
        [SerializeField] [Tooltip("A velocidade de abertura.")] protected float velocidade;
        [SerializeField] private TipoMovimentos tipoMovimento;

        public IMovimentos referenciaMovimento;
        public TipoMovimentos TipoMovimento => tipoMovimento;
        private Rigidbody2D _rigidbody2D;

        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            LeanTween.moveY(gameObject, 2.85f, 2);
        }
        private void FixedUpdate()
        {
            referenciaMovimento.Acao(_rigidbody2D, movimentoMaximo * Mathf.Sin(Time.time * velocidade));
        }
    }
}