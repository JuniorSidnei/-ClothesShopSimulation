using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClothesGame.Controllers {

    public class NpcController : MonoBehaviour {
        public float Speed;
        public Vector2 MovementInput;
        public float Acceleration;
        public float Drag;
        public float MovementRange = 4f;
        public bool DrawXRange;
        public bool DrawYRange;
        
        private Vector3 m_velocity;
        private Vector3 m_positionDelta;
        private Vector3 m_velocitySmoothing;

        private float m_minRangeX;
        private float m_maxRangeX;
        private float m_minRangeY;
        private float m_maxRangeY;
        
        public Vector3 Velocity {
            get => m_velocity;
            set => m_velocity = value;
        }

        private void Start() {
            var position = transform.position;
            m_minRangeX = position.x - MovementRange;
            m_maxRangeX = position.x + MovementRange;
            m_minRangeY = position.y - MovementRange;
            m_maxRangeY = position.y + MovementRange;

            Speed = Random.Range(1f, 1.25f);
        }

        private void FixedUpdate() {
            var targetVelocity = MovementInput * Speed;
            m_velocity = Vector3.SmoothDamp(m_velocity, targetVelocity, ref m_velocitySmoothing, Acceleration);
            
            var oldPos = transform.position;
            m_velocity *= (1 - Time.deltaTime * Drag);
            transform.Translate(m_velocity * Time.deltaTime);
            m_positionDelta = transform.position - oldPos;

            if (transform.position.x >= m_maxRangeX) {
                MovementInput.x = -1f;
            } else if (transform.position.x <= m_minRangeX) {
                MovementInput.x = 1f;
            }
            
            if (transform.position.y >= m_maxRangeY) {
                MovementInput.y = -1f;
            } else if (transform.position.y <= m_minRangeY) {
                MovementInput.y = 1f;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.magenta;
            var position = transform.position;
            if (DrawXRange) {
                Gizmos.DrawWireSphere(new Vector3(position.x - MovementRange, position.y, 1), .5f);
                Gizmos.DrawWireSphere(new Vector3(position.x + MovementRange, position.y, 1), .5f);    
            }

            if (DrawYRange) {
                Gizmos.DrawWireSphere(new Vector3(position.x, position.y + MovementRange, 1), .5f);
                Gizmos.DrawWireSphere(new Vector3(position.x, position.y - MovementRange, 1), .5f);    
            }
        }
    }

}