using System;
using ClothesGame.Managers;
using ClothesGame.Scriptables;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ClothesGame.ShopItem {
    
    public class MarketItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
       
        public ShopItemData ShopItem;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI PriceText;
        public Image ItemImage;
        public RectTransform ImageRectTransform;
        
        public void Setup(ShopItemData item) {
            ShopItem = item;

            switch (ShopItem.Type) {
                case ShopItemData.ItemType.Head:
                    ImageRectTransform.position = new Vector3(0, -25f, 1f);
                    break;
                case ShopItemData.ItemType.Torso:
                    ImageRectTransform.position = new Vector3(0, 10f, 1f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData) {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f);
        }

        public void OnPointerClick(PointerEventData eventData) {
            HudManager.Instance.MarketManager.SetItemInfo(ShopItem, gameObject);
        }

        public void OnPointerExit(PointerEventData eventData) {
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        }
        
        private void Start() {
            NameText.text = ShopItem.Name;
            PriceText.text = $"{ShopItem.Price}";
            ItemImage.sprite = ShopItem.Sprite;
        }
    }
}