namespace Game.S.Scripts.Interfaces.Efeitos
{
    using UnityEngine;
    
    public class Fade : MonoBehaviour, IEfeitos
    {
        public void Acao(CanvasGroup obj)
        {
            LeanTween.alphaCanvas(obj, obj.alpha == 0 ? 1 : 0, 3).setEaseInOutSine().setIgnoreTimeScale(true);
        }
    }
}