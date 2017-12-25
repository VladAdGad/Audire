using System;
using System.Linq;
using System.Runtime.CompilerServices;
using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;

namespace Player
{
    public class PlayerEventProducer : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        private GameObject _currentGameObject;
        private GameObject _previousGameObject;
        private readonly Vector2 _position = new Vector2(Screen.width / 2f, Screen.height / 2f);
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            Ray ray = _camera.ScreenPointToRay(_position);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, _interactionDistance))
            {
                Interact<IPressable>(TryPress);
                if (raycastHit.collider.gameObject.CompareTag("Interactable"))
                {
                    _currentGameObject = raycastHit.collider.gameObject;
                    Interact<IGazable>(gazeable => gazeable.OnGazeEnter());
                }
            }
            else
            {
                Interact<IGazable>(gazeable => gazeable.OnGazeExit());
            }
        }

        private static void TryPress(IPressable pressable)
        {
            if (Input.GetKeyDown(pressable.ActivationKeyCode()))
            {
                pressable.OnPress();
            }
        }

        private void Interact<T>(Action<T> action) where T : IIteractable
        {
            if (_currentGameObject != null)
                _currentGameObject
                    .GetComponents<IIteractable>()
                    .Where(interactable => interactable is T)
                    .Cast<T>()
                    .ToList()
                    .ForEach(action);
        }

        private void OnValidate()
        {
            Assert.AreNotEqual(_interactionDistance, 0);
        }
    }
}