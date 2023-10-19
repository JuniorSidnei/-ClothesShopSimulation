using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClothesGame.Managers {
    
    public class GameManager : MonoBehaviour {
        
        private void Awake() {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }
    }
}