using System.Collections.Generic;
using ClothesGame.Inventory;
using ClothesGame.Scriptables;

namespace ClothesGame.Managers {

    public static class InventoryManager {
        
        private static Dictionary<ShopItemData, InventoryItem> m_items = new Dictionary<ShopItemData, InventoryItem>();
        
        private static List<InventoryItem> m_inventoryItems = new List<InventoryItem>();

        public static List<InventoryItem> InventoryItems {
            get => m_inventoryItems;
            private set => m_inventoryItems = value;
        }

        public static InventoryItem GetItem(ShopItemData sourceData) {
            return m_items.TryGetValue(sourceData, out var value) ? value : null;
        }

        public static bool HasItem(ShopItemData sourceData) {
            return m_items.TryGetValue(sourceData, out var value);
        }
        
        public static void AddItem(ShopItemData sourceData, int sourceValue) {
            if (m_items.TryGetValue(sourceData, out InventoryItem value)) {
                value.Add(sourceValue);
            }
            else {
                var newItem = new InventoryItem(sourceData);
                m_inventoryItems.Add(newItem);
                m_items.Add(sourceData, newItem);
                newItem.Add(sourceValue);    
                
            }
        }
        
        public static void SetItem(ShopItemData sourceData, int sourceValue) {
            if (m_items.TryGetValue(sourceData, out InventoryItem value)) {
                value.Add(sourceValue);
            }
            else {
                var newItem = new InventoryItem(sourceData);
                m_inventoryItems.Add(newItem);
                m_items.Add(sourceData, newItem);
                newItem.Add(sourceValue);
            }
        }
        

        public static void RemoveItem(ShopItemData sourceData, int sourceValue) {
            if (!m_items.TryGetValue(sourceData, out InventoryItem value)) return;
            
            value.Remove(sourceValue);

            if (value.StackSize != 0) return;
                
            m_inventoryItems.Remove(value);
            m_items.Remove(sourceData);
            
        }
    }
}