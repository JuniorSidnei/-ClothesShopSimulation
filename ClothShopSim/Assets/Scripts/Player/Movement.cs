using System;
using ClothesGame.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothesGame.Player {


    public class Movement : MonoBehaviour {

        [SerializeField] private float m_drag;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_acceleration;
        
        private Vector3 m_velocity;
        private Vector3 m_positionDelta;
        private Vector3 m_velocitySmoothing;
        private Vector2 m_movementInput;
        
        public Vector3 Velocity {
            get => m_velocity;
            set => m_velocity = value;
        }

        public Vector3 PositionDelta {
            get => m_positionDelta;
        }

        private void Awake() {
            InputManager.Instance.PlayerMovement.performed += MovementAction;
            InputManager.Instance.PlayerMovement.canceled += MovementAction;
        }

        private void MovementAction(InputAction.CallbackContext ctx) {
            m_movementInput = ctx.ReadValue<Vector2>();
        }

        private void FixedUpdate() {
            var targetVelocity = m_movementInput * m_speed;
            Velocity = Vector3.SmoothDamp(Velocity, targetVelocity, ref m_velocitySmoothing, m_acceleration);
            
            var oldPos = transform.position;
            m_velocity *= (1 - Time.deltaTime * m_drag);
            var velocity = m_velocity * Time.deltaTime;
            transform.Translate(velocity);
            m_positionDelta = transform.position - oldPos;
        }
    }
}