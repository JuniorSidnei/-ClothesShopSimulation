using System;
using System.Collections;
using System.Collections.Generic;
using ClothesGame.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothesGame.ShopItem {
    
    public class ShopItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        
        public ShopItemData ShopItem;
        public TextMeshProUGUI NameText;

        private void Start() {
            NameText.text = ShopItem.Name;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            throw new System.NotImplementedException();
        }

        public void OnPointerClick(PointerEventData eventData) {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData) {
            throw new System.NotImplementedException();
        }
    }
}