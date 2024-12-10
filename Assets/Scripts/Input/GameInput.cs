using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class GameInput : MonoBehaviour
    {
        public static GameInput Instance { get; private set; }
        private InputSystem_Actions _inputSystem;

        public void Awake()
        {
            Instance = this;
            _inputSystem = new InputSystem_Actions();
            _inputSystem.Enable();
        }

        public float GetHorizontalMovementDirection()
        {
            Vector2 movementDirection = _inputSystem.Player.Move.ReadValue<Vector2>();
            
            return Math.Sign(movementDirection.x);
        }

        public float GetJumpInputMagnitude()
        {
            return _inputSystem.Player.Jump.WasPerformedThisFrame() ? 1.0f : 0.0f;
        }
    }
}
