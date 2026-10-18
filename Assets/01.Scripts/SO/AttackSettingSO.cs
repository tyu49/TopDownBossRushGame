using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackRangeSO", menuName = "Attack/Setting")]
public class AttackSettingSO : ScriptableObject
{
    [Header("Range")]
    [field:SerializeField] public float Distance { get; private set; }
    [field:SerializeField] public Vector2 Size { get; private set; }
    [field:Space(10)]
    [Header("AttackSetting")]
    [field:SerializeField] public ContactFilter2D Target { get; private set; }

    [field: SerializeField] public float DefaultDamage { get; private set; }


}