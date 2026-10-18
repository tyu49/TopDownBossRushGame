using TMPro;
using UnityEngine;

namespace _01.Scripts.Modules
{
    public class AttackModule : MonoBehaviour, IAttackable
    {
        [SerializeField] private int maxBuffer;
        private Collider2D[] _resultsArray;
        private ContactFilter2D _target;

        public void Initialize()
        {
            _resultsArray = new Collider2D[maxBuffer];
        }
        
        public void Attack(AttackSettingSO setting)
        {
            Vector2 pos = transform.position + transform.right * setting.Distance;
            int cnt = Physics2D.OverlapBox(pos, setting.Size, transform.eulerAngles.z, setting.Target, _resultsArray);
            if (cnt < 1) return;
            
            for (int i = 0; i < cnt; i++)
            {
                var target = _resultsArray[i];

                if (target.TryGetComponent<IDamageable>(out var compo))
                    compo.GetDamage(setting.DefaultDamage, this);
            }
        }
        
        
        
    }
}