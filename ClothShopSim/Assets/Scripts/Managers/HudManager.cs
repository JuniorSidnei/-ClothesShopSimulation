using System;
using System.Collections;
using System.Collections.Generic;
using ClothesGame.Controllers;
using ClothesGame.Utils;
using UnityEngine;

namespace ClothesGame.Managers {
    
    public class HudManager : Singleton<HudManager> {

        public ShopItemManager ShopItemManager;
        
        [Header("shop panels")]
        public GameObject HairShop;

        public void OpenHairShop(ShopHouseController.ShopType shopType) {
            switch (shopType) {
                case ShopHouseController.ShopType.Hair:
                    HairShop.SetActive(true);        
                    break;
                case ShopHouseController.ShopType.Clothes:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shopType), shopType, null);
            }
        }
    }
}