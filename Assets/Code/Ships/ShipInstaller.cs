using System;
using Code.Input;
using UnityEngine;

namespace Code.Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool useJoystick;
        [SerializeField] private GameObject joystick;
        [SerializeField] private Ship ship;

        private void Awake()
        {
            ship.Configure(GetInput());
        }

        private IInput GetInput()
        {
            if (useJoystick)
            {
                Instantiate(joystick);
            }
            return new PlayerInput();
        }
    }
}
