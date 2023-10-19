using ClothesGame.Player;
using UnityEngine;
using UnityEngine.Serialization;

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

        private void Awake() {
            m_currentHeadLayerIndex = headLayerIndex;
            m_currentTorsoLayerIndex = torsoLayerIndex;
            
            HeadAnimator.SetLayerWeight(m_currentHeadLayerIndex, 1);
            TorsoAnimator.SetLayerWeight(m_currentTorsoLayerIndex, 1);
        }

        private void Update() {
            var playerMovement = PlayerMovement.Velocity;
            
            BodyAnimator.SetFloat(MovementX, playerMovement.x);
            BodyAnimator.SetFloat(MovementY, playerMovement.y);
            HeadAnimator.SetFloat(MovementX, playerMovement.x);
            HeadAnimator.SetFloat(MovementY, playerMovement.y);
            TorsoAnimator.SetFloat(MovementX, playerMovement.x);
            TorsoAnimator.SetFloat(MovementY, playerMovement.y);
        }
    }
}