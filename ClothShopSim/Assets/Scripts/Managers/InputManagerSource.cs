using ClothesGame.Utils;
using UnityEngine.InputSystem;

namespace ClothesGame.Managers {

    public class InputManagerSource : Singleton<InputManagerSource> {
        
        private InputSource m_inputSource;

        public InputAction PlayerMovement { get; private set; }
        public InputAction PlayerInteract { get; private set; }

        private void OnEnable() {
            m_inputSource = new InputSource();
            m_inputSource.Enable();

            PlayerMovement = m_inputSource.Player.Movement;
            PlayerInteract = m_inputSource.Player.Interact;
        }
    }
    
}