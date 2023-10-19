using UnityEngine;

namespace ClothesGame.Scriptables {

    [CreateAssetMenu(menuName = "ShopItemData", fileName = "item_")]
    public class ShopItemData : ScriptableObject {

        public enum ItemType {
            Head, Torso    
        }

        public int AnimationLayerID;
        public string Name;
        [TextArea(1, 5)]
        public string Description;
        public int Price;
        public Sprite Sprite;
        public ItemType Type;
    }
}