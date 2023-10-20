using ClothesGame.Scriptables;
using ClothesGame.ShopItem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClothesGame.Managers {
    
    public class ShopItemManager : MonoBehaviour {

        public Image TorsoImage;
        public Image HeadImage;
        public TextMeshProUGUI ItemDescriptionText;
        public PlayerData PlayerData;
        public Button BuyBtn;
        public TextMeshProUGUI PlayerGoldText;
        
        private ShopItemData m_currentItem;
        private ShopItemSlot m_currentShopSlot;
        
        public void SetHairData(ShopItemData itemData, ShopItemSlot shopItemSlot) {
            SetItemInfo(itemData, shopItemSlot);
            SetupHeadItemData();
        }

        public void SetTorsoData(ShopItemData itemData, ShopItemSlot shopItemSlot) {
              SetItemInfo(itemData, shopItemSlot);
              SetupTorsoItemData();
        }
        
        public void BuyItem() {
            if(m_currentItem.Price > PlayerData.Gold) return;
            
            PlayerData.Gold -= m_currentItem.Price;
            GameManager.Instance.EquipCurrentItem(m_currentItem);
            InventoryManager.AddItem(m_currentItem, 1);
            PlayerGoldText.text = $"{PlayerData.Gold}";
            m_currentShopSlot.SetItemPurchased();
            m_currentItem = null;

            if (PlayerData.Gold <= 0) {
                BuyBtn.interactable = false;
            }
        }
        
        public void UpdateModelSprites() {
            if (PlayerData.CurrentEquippedHead != null) {
                HeadImage.color = Color.white;
                HeadImage.sprite = PlayerData.CurrentEquippedHead.Sprite;
            } else {
                HeadImage.color = Color.clear;
            }

            if (PlayerData.CurrentEquippedTorso != null) {
                TorsoImage.color = Color.white;
                TorsoImage.sprite = PlayerData.CurrentEquippedTorso.Sprite;    
            } else {
                TorsoImage.color = Color.clear;   
            }    
        }
        
        private void Awake() {
            PlayerGoldText.text = $"{PlayerData.Gold}";
            
            UpdateModelSprites();
        }

        private void SetupHeadItemData() {
            HeadImage.sprite = m_currentItem.Sprite;
            HeadImage.color = Color.white;
        }
        
        private void SetupTorsoItemData() {
            TorsoImage.sprite = m_currentItem.Sprite;
            TorsoImage.color = Color.white;
        }
        
        private void SetItemInfo(ShopItemData itemData, ShopItemSlot shopItemSlot) {
            m_currentItem = itemData;
            m_currentShopSlot = shopItemSlot;
            
            BuyBtn.interactable = PlayerData.Gold >= m_currentItem.Price;
            ItemDescriptionText.text = m_currentItem.Description;
        }
    }
}