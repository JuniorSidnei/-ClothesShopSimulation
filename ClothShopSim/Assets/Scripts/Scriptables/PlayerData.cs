using UnityEngine;

namespace ClothesGame.Scriptables {

    [CreateAssetMenu(menuName = "PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject {
        
        public ShopItemData CurrentEquippedTorso;
        public ShopItemData CurrentEquippedHead;
        public int Gold;
    }
}