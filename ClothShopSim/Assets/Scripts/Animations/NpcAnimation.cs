using System;
using ClothesGame.Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClothesGame.Animations {

    public class NpcAnimation : MonoBehaviour {
        
        [Header("Animators")]
        public Animator BodyAnimator;
        public Animator HeadAnimator;
        public Animator TorsoAnimator;

        public NpcController NpcController;
        
        [Header("animation layer")]
        private int m_currentHeadLayerIndex;
        private int m_currentTorsoLayerIndex;
        
        private static readonly int MovementX = Animator.StringToHash("movement_x");
        private static readonly int MovementY = Animator.StringToHash("movement_y");
        
        private void Start() {
            var randomHead = 0;
            var randomTorso = 0;
            
            randomHead = Random.Range(1, 5);
            randomTorso = Random.Range(1, 5);
            
            m_currentHeadLayerIndex = randomHead;
            m_currentTorsoLayerIndex =  randomTorso;
            
            HeadAnimator.SetLayerWeight(m_currentHeadLayerIndex, 1);
            TorsoAnimator.SetLayerWeight(m_currentTorsoLayerIndex, 1);
        }
        
        private void Update() {
            var npcMovement = NpcController.Velocity;
            
            BodyAnimator.SetFloat(MovementX, npcMovement.x);
            BodyAnimator.SetFloat(MovementY, npcMovement.y);
            HeadAnimator.SetFloat(MovementX, npcMovement.x);
            HeadAnimator.SetFloat(MovementY, npcMovement.y);
            TorsoAnimator.SetFloat(MovementX, npcMovement.x);
            TorsoAnimator.SetFloat(MovementY, npcMovement.y);
        }
    }

}