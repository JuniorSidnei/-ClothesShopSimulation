using System;
using System.Collections.Generic;
using ClothesGame.Animations;
using ClothesGame.Scriptables;
using ClothesGame.ShopItem;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ClothesGame.Managers {

    public class MarketManager : MonoBehaviour {

        public GameObject ItemPrefab;
        public TextMeshProUGUI ItemDescriptionText;
        public PlayerData PlayerData;
        public Button SellBtn;
        public TextMeshProUGUI PlayerGoldText;
        public Transform ItemGridTransform;
        
        private ShopItemData m_currentItem;
        private GameObject m_currentShopSlot;
        private List<GameObject> m_shopItemsObj = new List<GameObject>();

        public void ClearItems() {
            foreach (var item in m_shopItemsObj) {
                Destroy(item);
            }    
        }
        
        public void SpawnItemSlots() {
            PlayerGoldText.text = $"{PlayerData.Gold}";
            
            foreach (var item in InventoryManager.InventoryItems) {
                var itemSlot = Instantiate(ItemPrefab, Vector3.zero, quaternion.identity, ItemGridTransform);
                itemSlot.GetComponent<MarketItemSlot>().Setup(item.ItemData);
                m_shopItemsObj.Add(itemSlot);
            }
        }
        
        public void SellItem() {
            if(m_currentItem == null) return;
            
            PlayerData.Gold += m_currentItem.SellPrice;
            ValidateIfEquipped(m_currentItem);
            InventoryManager.RemoveItem(m_currentItem, 1);
            m_currentItem = null;
            ItemDescriptionText.text = "";
            PlayerGoldText.text = $"{PlayerData.Gold}";
            Destroy(m_currentShopSlot);
        }
        
        public void SetItemInfo(ShopItemData itemData, GameObject shopItemSlot) {
            m_currentItem = itemData;
            m_currentShopSlot = shopItemSlot;
            
            ItemDescriptionText.text = m_currentItem.Description;
        }
        
        private void ValidateIfEquipped(ShopItemData currentItem) {
            switch (currentItem.Type) {
                case ShopItemData.ItemType.Head:
                    if (m_currentItem == PlayerData.CurrentEquippedHead) {
                        PlayerData.CurrentEquippedHead = null;
                        GameManager.Instance.PlayerAnimation.UpdateHeadAnimation(0);
                    }
                    break;
                case ShopItemData.ItemType.Torso:
                    if (m_currentItem == PlayerData.CurrentEquippedTorso) {
                        PlayerData.CurrentEquippedTorso = null;
                        GameManager.Instance.PlayerAnimation.UpdateTorsoAnimation(0);
                    }
                    break;
            }
        }

        private void Awake() {
            PlayerGoldText.text = $"{PlayerData.Gold}";
        }
    }
}