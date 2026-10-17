using UnityEngine;
using UnityEngine.InputSystem;

namespace _01.Scripts.UtilClass
{
    public static class GetMousePos
    {
        private static Camera _mainCam;
        public static Vector2 GetPos()
        {
            if (_mainCam == null) _mainCam = Camera.main;
            if (_mainCam != null) return _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.LogError("there no mainCamera");
            return Vector2.zero;
        }
    }
}