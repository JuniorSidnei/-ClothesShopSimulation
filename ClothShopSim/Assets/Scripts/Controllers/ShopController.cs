using ClothesGame.Managers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothesGame.Controllers {


    public abstract class ShopController : MonoBehaviour {

        public LayerMask PlayerLayer;
        public GameObject MessageBox;

        protected bool m_isPlayerInSight;
        
        protected abstract void OpenShop(InputAction.CallbackContext obj);
        
        private void Start() {
            InputManagerSource.Instance.PlayerInteract.performed += OpenShop;
            InputManagerSource.Instance.PlayerInteract.Disable();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(((1 << other.gameObject.layer) & PlayerLayer) == 0) return;
            
            EnableSettingsIn();
            InputManagerSource.Instance.PlayerInteract.Enable();
        }
        
        private void OnTriggerExit2D(Collider2D other) {
            if(((1 << other.gameObject.layer) & PlayerLayer) == 0) return;
            
            EnableSettingsOut();
            InputManagerSource.Instance.PlayerInteract.Disable();
        }

        private void EnableSettingsIn() {
            MessageBox.SetActive(true);
            MessageBox.transform.DOScale(new Vector3(1f, 1f, 1f), 0.35f);
            m_isPlayerInSight = true;
        }
        
        private void EnableSettingsOut() {
            m_isPlayerInSight = false;
            MessageBox.transform.DOScale(new Vector3(0f, 0f, 0f), 0.35f).OnComplete(() => {
                MessageBox.SetActive(false);
            });
        }
    }
}