using ClothesGame.Managers;
using ClothesGame.Scriptables;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClothesGame.ShopItem {
    
    public class ShopItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        
        public ShopItemData ShopItem;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI PriceText;
        public Image ItemImage;
        public AudioSource HoverSource;
        public AudioSource ConfirmSource;
        
        private bool m_isPurchased;

        public void Setup(ShopItemData itemData) {
            ShopItem = itemData;
        }
        
        public void SetItemPurchased() {
            m_isPurchased = true;
            ItemImage.color = Color.gray;
        } 
        
        public void OnPointerEnter(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            HoverSource.Play();
            transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f);
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            ConfirmSource.Play();
            HudManager.Instance.ShowShop(ShopItem, this, ShopItem.Type);
        }

        public void OnPointerExit(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        }
        
        private void Start() {
            NameText.text = ShopItem.Name;
            PriceText.text = $"{ShopItem.Price}";
            ItemImage.sprite = ShopItem.Sprite;

            var item = InventoryManager.GetItem(ShopItem);
            
            if (item == null) return;
            
            if (item.StackSize < 1) return;
            
            SetItemPurchased();
        }
    }
}