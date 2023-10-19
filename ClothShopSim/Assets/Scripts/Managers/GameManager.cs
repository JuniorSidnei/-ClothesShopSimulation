using System;
using ClothesGame.Animations;
using ClothesGame.Scriptables;
using ClothesGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClothesGame.Managers {
    
    public class GameManager : Singleton<GameManager> {

        public PlayerData PlayerData;
        public PlayerAnimation PlayerAnimation;
        
        private void Awake() {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        public void EquipCurrentItem(ShopItemData shopItemData) {
            switch (shopItemData.Type) {
                case ShopItemData.ItemType.Head:
                    PlayerData.CurrentEquippedHead = shopItemData;
                    PlayerAnimation.UpdateHeadAnimation(shopItemData.AnimationLayerID);
                    break;
                case ShopItemData.ItemType.Torso:
                    PlayerData.CurrentEquippedTorso = shopItemData;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}