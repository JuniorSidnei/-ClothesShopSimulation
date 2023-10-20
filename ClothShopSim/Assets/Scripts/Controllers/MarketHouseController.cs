using ClothesGame.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothesGame.Controllers {

    public class MarketHouseController : ShopController {

        protected override void OpenShop(InputAction.CallbackContext obj) {
            if(!m_isPlayerInSight) return;
            
            HudManager.Instance.OpenMarketShop();
        }
    }
}