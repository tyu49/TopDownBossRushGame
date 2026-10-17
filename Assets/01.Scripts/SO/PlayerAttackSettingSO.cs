using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "PlayerAttackSetting", menuName = "PlayerAttackSettingSO", order = 0)]
    public class PlayerAttackSettingSO : ScriptableObject
    {
        [field: SerializeField] public AttackRangeSo AttackRange { get; private set; }
        [field:SerializeField] public float DefaultDamage { get; private set; }
        
        
    }
}