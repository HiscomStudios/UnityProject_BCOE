namespace Game.S.Scripts.MVC.View
{
    using UnityEngine;
    using Enumeradores;
    
    public class Ingrediente : MonoBehaviour
    {
        [SerializeField] private TipoIngrediente tipoIngrediente;
        
        public TipoIngrediente TipoIngrediente => tipoIngrediente;
        public Rigidbody2D Rb2d {get; private set;}
        private AudioSource _som;
        
        
        private void Awake()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            _som = GameObject.Find("Bater").GetComponent<AudioSource>();
        }
        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.collider.CompareTag("Ingrediente"))
                _som.Play();
        }
    }
}