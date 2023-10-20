using ClothesGame.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothesGame.Controllers {

    public class HairHouseController : ShopController {

        protected override void OpenShop(InputAction.CallbackContext obj) {
            if(!m_isPlayerInSight) return;
            
            HudManager.Instance.OpenHairShop();
        }
    }
}