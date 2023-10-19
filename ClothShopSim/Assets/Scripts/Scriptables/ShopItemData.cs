using UnityEngine;

namespace ClothesGame.Scriptables {

    [CreateAssetMenu(menuName = "ShopItemData", fileName = "item_")]
    public class ShopItemData : ScriptableObject {
        
        public string Name;
        [TextArea(1, 5)]
        public string Description;
        public int Price;
    }
}