using System;
using UnityEngine;

namespace _01.Scripts.TestScripts
{
    public class AttackRangeViewer : MonoBehaviour
    {
        [SerializeField] private AttackRangeSo rangeSo;
        [SerializeField] private bool debug;

        private void OnDrawGizmos()
        {
            if (rangeSo == null) return;
            if (!debug) return;
            Gizmos.color = Color.red;
            Matrix4x4 basicMatrix = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(
                (Vector2)transform.position + rangeSo.pos,
                Quaternion.Euler(0f, 0f, rangeSo.angle),
                Vector3.one
            );
            Gizmos.DrawWireCube(Vector2.zero, rangeSo.size);

            Gizmos.matrix = basicMatrix;

        }
    }
}