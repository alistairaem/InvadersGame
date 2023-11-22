using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    public class PlayerInput : IInput
    {
        private InputActions _inputActions;
        private InputAction _action;
        private Vector2 _direction;


        public PlayerInput()
        {
            Config();
        }

        ~PlayerInput()
        {
            _action.Disable();
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        private void SetDirection(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _direction = _action.ReadValue<Vector2>();
            }

            if (context.canceled)
            {
                _direction = Vector2.zero;
            }
        }

        private void Config()
        {
            _inputActions = new InputActions();
            _action = _inputActions.Player.Move;
            _action.Enable();

            _action.performed += SetDirection;
            _action.canceled += SetDirection;
        }
    }
}
