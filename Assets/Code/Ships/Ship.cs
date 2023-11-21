using Code.Input;
using UnityEngine;

namespace Code.Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform _transform;
        private Camera _camera;
        private IInput _input;

        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
        }

        public void Configure(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            Move(_input.GetDirection());
        }

        private void Move(Vector2 direction)
        {
            _transform.Translate(direction * (speed * Time.deltaTime));
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.06f, 0.94f);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}
