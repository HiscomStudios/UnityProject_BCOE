namespace Game.S.Scripts.MVC.Model
{
    using System;
    using System.Collections;
    using UnityEngine;
    
    public static class Tempo
    {
        public static void AlterarEscalaDeTempo()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        public static void ExecutarAcaoAposTempo(this MonoBehaviour mono, Action method, float delay)
        {
            mono.StartCoroutine(ExecutarAcaoAposTempoCoroutine(method, delay));
        }
        public static void ExecutarAcaoAposTempo<T>(this MonoBehaviour mono, Action<T> method, float delay, T parameter)
        {
            mono.StartCoroutine(ExecutarAcaoAposTempoCoroutine(method, delay, parameter));
        }

        private static IEnumerator ExecutarAcaoAposTempoCoroutine(Action method, float delay)
        {
            yield return new WaitForSeconds(delay);
            method();
        }
        private static IEnumerator ExecutarAcaoAposTempoCoroutine<T>(Action<T> method, float delay, T parameter)
        {
            yield return new WaitForSeconds(delay);
            method(parameter);
        }
    }
}