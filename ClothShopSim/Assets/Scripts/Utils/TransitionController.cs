using System;
using DG.Tweening;
using UnityEngine.UI;

namespace ClothesGame.Utils {
    
    public class TransitionController : Singleton<TransitionController> {

        public Image Transition;

        public void DoTransitionIn(Action onFinishTransition = null) {
            gameObject.SetActive(true);
            Transition.DOFade(1f, 0.5f).OnComplete(() => {
                onFinishTransition?.Invoke();
            });
        }
        
        public void DoTransitionOut(Action onFinishTransition = null) {
            gameObject.SetActive(true);
            Transition.DOFade(0f, 0.5f).OnComplete(() => {
                onFinishTransition?.Invoke();
                gameObject.SetActive(false);
            });
        }
    }

}