using System;
using System.Collections;
using System.Collections.Generic;
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
        public Image ItemImage;

        private bool m_isPurchased;

        public void SetItemPurchased() {
            m_isPurchased = true;
            ItemImage.color = Color.gray;
        } 
        
        public void OnPointerEnter(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f);
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            HudManager.Instance.ShopItemManager.SetItemInfo(ShopItem, this);
        }

        public void OnPointerExit(PointerEventData eventData) {
            if(m_isPurchased) return;
            
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        }
        
        private void Start() {
            NameText.text = ShopItem.Name;
            ItemImage.sprite = ShopItem.Sprite;

            var item = InventoryManager.GetItem(ShopItem);
            
            if (item == null) return;
            
            if (item.StackSize < 1) return;
            
            SetItemPurchased();
        }
    }
}