using ClothesGame.Scriptables;

namespace ClothesGame.Inventory {
    
    public class InventoryItem {
        
        public ShopItemData ItemData;
        public int StackSize { get; private set; }

        public InventoryItem(ShopItemData sourceData) {
            ItemData = sourceData;
            Add(0);
        }

        public void Add(int value) {
            StackSize += value;
        }

        public void Remove(int value) {
            StackSize -= value;
        }
    }
}