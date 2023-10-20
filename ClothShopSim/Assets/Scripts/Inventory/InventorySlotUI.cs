using System;
using ClothesGame.Managers;
using ClothesGame.Scriptables;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClothesGame.Inventory {

    public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        
        public ShopItemData ShopItem;
        public TextMeshProUGUI EquippedText;
        public TextMeshProUGUI NameText;
        public Image ItemImage;
        public Image SlotBg;
        public RectTransform ImageRectTransform;
        
        public void SetSelected(bool selected) {
            SlotBg.color = selected ? Color.gray : Color.white;
        }
        
        public void Setup(ShopItemData item) {
            var playerData = GameManager.Instance.PlayerData;
            
            ShopItem = item;

            NameText.text = ShopItem.Name;
            ItemImage.sprite = ShopItem.Sprite;

            var isEquipped = false;
            
            switch (ShopItem.Type) {
                case ShopItemData.ItemType.Head:
                    isEquipped = playerData.CurrentEquippedHead == ShopItem;
                    ApplySettings(new Vector3(0f, -25f, 1f), isEquipped, this, false);
                    break;
                case ShopItemData.ItemType.Torso:
                    isEquipped = playerData.CurrentEquippedTorso == ShopItem;
                    ApplySettings(new Vector3(0f, 10f, 1f), isEquipped, this, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ApplySettings(Vector3 position, bool isEquipped, InventorySlotUI item, bool isTorso) {
            ImageRectTransform.localPosition = position;
            
            EquippedText.text =  isEquipped ? "Equipped" : "Equip";
                    
            if (isEquipped) {
                if (isTorso) {
                    HudManager.Instance.InventoryController.SetTorsoInventoryItem(item);    
                }
                else {
                    HudManager.Instance.InventoryController.SetHeadInventoryItem(item);
                }
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData) {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f);
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (ShopItem.Type == ShopItemData.ItemType.Head) {
                HudManager.Instance.InventoryController.SetHeadInventoryItem(this);
            }
            else {
                HudManager.Instance.InventoryController.SetTorsoInventoryItem(this);    
            }
        }

        public void OnPointerExit(PointerEventData eventData) {
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        }

        public void UpdateText(bool equipped) {
            EquippedText.text = equipped ? "Equipped" : "Equip";
        }
    }
}