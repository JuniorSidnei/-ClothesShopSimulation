using ClothesGame.Utils;
using UnityEngine.InputSystem;

namespace ClothesGame.Managers {

    public class InputManager : Singleton<InputManager> {
        
        private InputSource m_inputSource;

        public InputAction PlayerMovement;

        private void OnEnable() {
            m_inputSource = new InputSource();
            m_inputSource.Enable();

            PlayerMovement = m_inputSource.Player.Movement;
        }
    }
    
}