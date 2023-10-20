using System;
using ClothesGame.Controllers;
using ClothesGame.Inventory;
using ClothesGame.Scriptables;
using ClothesGame.ShopItem;
using ClothesGame.Utils;
using UnityEngine;

namespace ClothesGame.Managers {
    
    public class HudManager : Singleton<HudManager> {

        public ShopItemManager HairShopManager;
        public ShopItemManager ClothesShopManager;
        public MarketManager MarketManager;
        public InventoryController InventoryController;
        
        [Header("shop panels")]
        public GameObject HairShop;
        public GameObject ClothesShop;
        public GameObject MarketShop;

        public void OpenHairShop() {
            HairShopManager.UpdateModelSprites();
            HairShop.SetActive(true);
        }
        
        public void OpenClothesShop() {
            ClothesShopManager.UpdateModelSprites();
            ClothesShop.SetActive(true);
        }

        public void OpenMarketShop() {
            MarketShop.SetActive(true);
            MarketManager.SpawnItemSlots();
        }
        
        public void ShowShop(ShopItemData shopItem, ShopItemSlot shopItemSlot, ShopItemData.ItemType shopType) {
            switch (shopType) {
                case ShopItemData.ItemType.Head:
                    HairShopManager.SetHairData(shopItem, shopItemSlot);
                    break;
                case ShopItemData.ItemType.Torso:
                    ClothesShopManager.SetTorsoData(shopItem, shopItemSlot);   
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shopType), shopType, null);
            }
        }
    }
}