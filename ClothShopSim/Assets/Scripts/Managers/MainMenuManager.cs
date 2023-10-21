using System;
using ClothesGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClothesGame.Managers {

    public class MainMenuManager : MonoBehaviour {

        public void PlayGame() {
            TransitionController.Instance.DoTransitionIn(() => {
                SceneManager.LoadScene("ShopScene");
            });
        }

        public void QuitGame() {
            Application.Quit();
        }

        private void Awake() {
            TransitionController.Instance.DoTransitionOut(); 
        }
    }

}