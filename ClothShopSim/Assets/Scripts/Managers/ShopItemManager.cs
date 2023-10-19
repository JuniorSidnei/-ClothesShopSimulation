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
        public TextMeshProUGUI ItemPriceText;
        public PlayerData PlayerData;
        public Button BuyBtn;
        public TextMeshProUGUI PlayerGoldText;
        
        private ShopItemData m_currentItem;
        private ShopItemSlot m_currentShopSlot;
        
        public void SetItemInfo(ShopItemData itemData, ShopItemSlot shopItemSlot) {
            m_currentItem = itemData;
            m_currentShopSlot = shopItemSlot;
            SetupItemData();
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
        
        private void Awake() {
            TorsoImage.sprite = PlayerData.CurrentEquippedTorso.Sprite;
            HeadImage.sprite = PlayerData.CurrentEquippedHead.Sprite;

            PlayerGoldText.text = $"{PlayerData.Gold}";
        }

        private void SetupItemData() {
            BuyBtn.interactable = PlayerData.Gold >= m_currentItem.Price;
            
            ItemDescriptionText.text = m_currentItem.Description;
            ItemPriceText.text = $"{m_currentItem.Price}";
            HeadImage.sprite = m_currentItem.Sprite;
        }
    }
}