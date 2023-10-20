using System;
using System.Collections.Generic;
using ClothesGame.Inventory;
using ClothesGame.Managers;
using ClothesGame.Scriptables;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ClothesGame.Controllers {


    public class InventoryController : MonoBehaviour {
        
        public GameObject ItemPrefab;
        public PlayerData PlayerData;
        public Button EquipBtn;
        public Button EquipTorsoBtn;
        public Transform ItemGridTransform;
        public Transform ItemTorsoGridTransform;
        public TextMeshProUGUI PlayerGoldText;
        
        private InventorySlotUI m_currentTorsoItem;
        private InventorySlotUI m_currentHeadItem;
        private List<GameObject> m_shopItemsObj = new List<GameObject>();
        private bool m_isOpen;
        private bool m_isTransitiongoing;
        private InventorySlotUI m_oldTorsoEquippedItem;
        private InventorySlotUI m_oldHeadEquippedItem;

        public void OpenInventory() {
            if(m_isTransitiongoing) return;
            
            m_isTransitiongoing = true;
            
            if (m_isOpen) {
                Hide();
            }
            else {
                GameManager.Instance.CurrentPlayerState = GameManager.PlayerState.HudAction;
                gameObject.SetActive(true);
                PlayerGoldText.text = $"{PlayerData.Gold}";
                SpawnItemSlots();
                transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f).OnComplete(() => {
                    m_isOpen = true;
                    m_isTransitiongoing = false;
                });
            }    
        }
        
        public void EquipSelectedItem() {
            if(m_currentTorsoItem == null) return;
            
            if (PlayerData.CurrentEquippedTorso != m_currentTorsoItem.ShopItem) {
                m_currentTorsoItem.SetSelected(false);
                m_currentTorsoItem.UpdateText(false);
            }
            
            PlayerData.CurrentEquippedTorso = m_currentTorsoItem.ShopItem;
            GameManager.Instance.PlayerAnimation.UpdateTorsoAnimation(m_currentTorsoItem.ShopItem.AnimationLayerID);
                    
            if (m_oldTorsoEquippedItem != null) {
                m_oldTorsoEquippedItem.UpdateText(false);
            }
            
            m_currentTorsoItem.UpdateText(true);
            SetTorsoInventoryItem(m_currentTorsoItem);
        }

        public void EquipSelectedHead() {
            if(m_currentHeadItem == null) return;
            
            if (PlayerData.CurrentEquippedHead != m_currentHeadItem.ShopItem) {
                  m_currentHeadItem.SetSelected(false);
                  m_currentHeadItem.UpdateText(false);
            }
            
            PlayerData.CurrentEquippedHead = m_currentHeadItem.ShopItem;
            GameManager.Instance.PlayerAnimation.UpdateHeadAnimation(m_currentHeadItem.ShopItem.AnimationLayerID);
            
                      
            if (m_oldHeadEquippedItem != null) {
                m_oldHeadEquippedItem.UpdateText(false);
            }
            
            m_currentHeadItem.UpdateText(true);
            SetHeadInventoryItem(m_currentHeadItem);
        }
        
        public void SetTorsoInventoryItem(InventorySlotUI currentItem) {
            if (m_currentTorsoItem != null && m_currentTorsoItem != currentItem) {
                m_currentTorsoItem.SetSelected(false);
                m_oldTorsoEquippedItem = m_currentTorsoItem;
            }
            
            m_oldTorsoEquippedItem = m_currentTorsoItem;
            m_currentTorsoItem = currentItem;
            m_currentTorsoItem.SetSelected(true);
        }
        
        public void SetHeadInventoryItem(InventorySlotUI currentItem) {
            if (m_currentHeadItem != null && m_currentHeadItem != currentItem) {
                m_currentHeadItem.SetSelected(false);
                m_oldHeadEquippedItem = m_currentTorsoItem;
            }
            
            m_oldHeadEquippedItem = m_currentHeadItem;
            m_currentHeadItem = currentItem;
            m_currentHeadItem.SetSelected(true);
        }
        
        public void Hide() {
            m_isTransitiongoing = true;
            transform.DOScale(Vector3.zero, .5f).OnComplete(() => {
                ClearItems();
                m_currentTorsoItem = null;
                m_oldTorsoEquippedItem = null;
                m_currentHeadItem = null;
                m_oldHeadEquippedItem = null;
                m_isTransitiongoing = false;
                m_isOpen = false;
                GameManager.Instance.CurrentPlayerState = GameManager.PlayerState.Walking;
                gameObject.SetActive(false);    
            });
        }
        
        private void ClearItems() {
            foreach (var item in m_shopItemsObj) {
                Destroy(item);
            }
        }

        private void SpawnItemSlots() {
            foreach (var item in InventoryManager.InventoryItems) {
                var itemSlot = Instantiate(ItemPrefab, Vector3.zero, quaternion.identity, item.ItemData.Type == ShopItemData.ItemType.Head ? ItemGridTransform : ItemTorsoGridTransform);
                itemSlot.GetComponent<InventorySlotUI>().Setup(item.ItemData);
                m_shopItemsObj.Add(itemSlot);
            }
        }
        
        private void Awake() {
            InputManagerSource.Instance.PlayerInventory.performed += OpenInventoryAction;
        }

        private void OnDestroy() {
            if(!InputManagerSource.Instance) return;
            
            InputManagerSource.Instance.PlayerInventory.performed -= OpenInventoryAction;
        }

        private void OpenInventoryAction(InputAction.CallbackContext ctx) {
            OpenInventory();
        }
    }

}