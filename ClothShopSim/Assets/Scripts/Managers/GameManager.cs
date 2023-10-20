using ClothesGame.Animations;
using ClothesGame.Scriptables;
using ClothesGame.Utils;
using UnityEngine.SceneManagement;

namespace ClothesGame.Managers {
    
    public class GameManager : Singleton<GameManager> {

        public enum PlayerState {
            Walking, HudAction    
        }
        
        public PlayerData PlayerData;
        public PlayerAnimation PlayerAnimation;
        public PlayerState CurrentPlayerState;
        
        private void Awake() {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }
    }
}