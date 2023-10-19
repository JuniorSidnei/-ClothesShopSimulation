using UnityEngine;

namespace ClothesGame.Scriptables {

    [CreateAssetMenu(menuName = "PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject {
        
        public int CurrentEquippedTorso;
        public int CurrentEquippedHead;
    }
}