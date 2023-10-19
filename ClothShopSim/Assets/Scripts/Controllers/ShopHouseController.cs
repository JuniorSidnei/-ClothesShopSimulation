using ClothesGame.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothesGame.Controllers {

    public class ShopHouseController : MonoBehaviour {
        public enum ShopType {
            Hair, Clothes    
        }
        
        public LayerMask PlayerLayer;
        public GameObject MessageBox;
        public ShopType Shop;
        
        private void Start() {
            InputManagerSource.Instance.PlayerInteract.performed += OpenShop;
            InputManagerSource.Instance.PlayerInteract.Disable();
        }

        private void OpenShop(InputAction.CallbackContext obj) {
            HudManager.Instance.OpenHairShop(Shop);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(((1 << other.gameObject.layer) & PlayerLayer) == 0) return;
            
            MessageBox.SetActive(true);
            InputManagerSource.Instance.PlayerInteract.Enable();
        }
        
        private void OnTriggerExit2D(Collider2D other) {
            if(((1 << other.gameObject.layer) & PlayerLayer) == 0) return;
            
            MessageBox.SetActive(false);
            InputManagerSource.Instance.PlayerInteract.Disable();
        }
    }
}