using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackRangeSO", menuName = "Attack/BoxRange")]
public class AttackRangeSo : ScriptableObject
{
    [field:SerializeField] public Vector2 pos { get; private set; }
    [field:SerializeField] public Vector2 size { get; private set; }
    [field:SerializeField] public float angle { get; private set; }
}