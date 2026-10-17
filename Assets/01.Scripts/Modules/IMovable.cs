using UnityEngine;

namespace _01.Scripts.Modules
{
    public interface IMovable
    {
        void Push(Vector2 dir, float pow, ForceMode2D forceMode);
        void SetMoveDir(Vector2 dir);
    }
}