using ClothesGame.Player;
using UnityEngine;

namespace ClothesGame.Animations {
        
    public class PlayerAnimation : MonoBehaviour {

        public int headLayerIndex;
        public int torsoLayerIndex;
        
        public Movement PlayerMovement;
        
        [Header("Animators")]
        public Animator BodyAnimator;
        public Animator HeadAnimator;
        public Animator TorsoAnimator;
        
        private static readonly int MovementX = Animator.StringToHash("movement_x");
        private static readonly int MovementY = Animator.StringToHash("movement_y");

        [Header("animation layer")]
        private int m_currentHeadLayerIndex;
        private int m_currentTorsoLayerIndex;
        private bool m_isAnimatingHead;
        private bool m_isAnimatingTorso;
        
        private void Awake() {
            m_currentHeadLayerIndex = headLayerIndex;
            m_currentTorsoLayerIndex = torsoLayerIndex;
            
            UpdateHeadAnimation(m_currentHeadLayerIndex);
            UpdateTorsoAnimation(m_currentTorsoLayerIndex);
        }

        private void Update() {
            var playerMovement = PlayerMovement.Velocity;
            
            BodyAnimator.SetFloat(MovementX, playerMovement.x);
            BodyAnimator.SetFloat(MovementY, playerMovement.y);

            if (m_isAnimatingHead) {
                HeadAnimator.SetFloat(MovementX, playerMovement.x);
                HeadAnimator.SetFloat(MovementY, playerMovement.y);    
            }

            if (m_isAnimatingTorso) {
                TorsoAnimator.SetFloat(MovementX, playerMovement.x);
                TorsoAnimator.SetFloat(MovementY, playerMovement.y);    
            }
        }

        public void UpdateHeadAnimation(int animationLayerID) {
            if (animationLayerID == 0) {
                m_currentHeadLayerIndex = animationLayerID;
                HeadAnimator.gameObject.SetActive(false);
                m_isAnimatingHead = false;
                return;
            }
            
            HeadAnimator.gameObject.SetActive(true);
            m_isAnimatingHead = true;
            
            if (m_currentHeadLayerIndex != 0) {
                HeadAnimator.SetLayerWeight(m_currentHeadLayerIndex, 0);
            }

            m_currentHeadLayerIndex = animationLayerID;
            HeadAnimator.SetLayerWeight(m_currentHeadLayerIndex, 1);
        }
        
        public void UpdateTorsoAnimation(int animationLayerID) {
            if (animationLayerID == 0) {
                m_currentTorsoLayerIndex = animationLayerID;
                TorsoAnimator.gameObject.SetActive(false);
                m_isAnimatingTorso = false;
                return;
            }
            
            TorsoAnimator.gameObject.SetActive(true);
            m_isAnimatingTorso = true;
            
            if (m_currentTorsoLayerIndex != 0) {
                TorsoAnimator.SetLayerWeight(m_currentTorsoLayerIndex, 0);
            }

            m_currentTorsoLayerIndex = animationLayerID;
            TorsoAnimator.SetLayerWeight(m_currentTorsoLayerIndex, 1);
        }
    }
}