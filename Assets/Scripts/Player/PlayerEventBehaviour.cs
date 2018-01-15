using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;
using Utilities;

namespace Player
{
    public class PlayerEventBehaviour : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        private IEnumerable<IGazable> _previousGazeable = new HashSet<IGazable>();
        private readonly Vector2 _position = new Vector2(Screen.width / 2f, Screen.height / 2f);
        private Camera _camera;

        private void Start() => _camera = Camera.main;

        private void Update() => GazeCast()
            .Map(raycastHit => raycastHit.collider)
            .Map(raycastHitCollider => raycastHitCollider.GetComponents<IInteractable>())
            .Do(interactables => MoveEyesightOn(CurrentGazeablesOf(interactables)))
            .Do(Press);

        private Optional<RaycastHit> GazeCast()
        {
            RaycastHit raycastHit;

            if (!Physics.Raycast(_camera.ScreenPointToRay(_position), out raycastHit, _interactionDistance))
            {
                MoveEyesightOn(new List<IGazable>());
            }

            return Optional<RaycastHit>.Of(raycastHit);
        }

        private static void Press(IEnumerable<IInteractable> interactables) => interactables
            .Where(it => it is IPressable)
            .Cast<IPressable>()
            .Where(pressable => Input.GetKeyDown(pressable.ActivationKeyCode()))
            .ToList()
            .ForEach(pressable => pressable.OnPress());

        private static IList<IGazable> CurrentGazeablesOf(IEnumerable<IInteractable> interactables) => interactables
            .Where(it => it is IGazable)
            .Cast<IGazable>()
            .ToList();

        private void MoveEyesightOn(IList<IGazable> gazables)
        {
            LookAt(gazables);
            StopLookingAt(gazables);
            _previousGazeable = gazables;
        }

        private void StopLookingAt(IEnumerable<IGazable> gazables) => InvokeOn(_previousGazeable.Except(gazables), gazeable => gazeable.OnGazeExit());

        private void LookAt(IEnumerable<IGazable> gazables) => InvokeOn(gazables.Except(_previousGazeable), gazeable => gazeable.OnGazeEnter());

        private static void InvokeOn<T>(IEnumerable<T> enumerable, Action<T> action) => enumerable
            .ToList()
            .ForEach(action.Invoke);

        private void OnValidate() => Assert.AreNotEqual(_interactionDistance, 0);
    }
}
