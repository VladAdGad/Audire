﻿using EventManagement.Interfaces;
using Gui;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class DoorBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] protected TooltipGuiSocket TooltipGuiSocket;
        [SerializeField] protected string ToolTipOpenText;
        [SerializeField] protected string ToolTipCloseText;
        [SerializeField] protected KeyCode ActivationButton = KeyCode.E;
        [SerializeField] private AudioSource _closingDoorAudioSource;
        [SerializeField] private AudioSource _openingDoorAudioSource;

        private Animator _animator;
        protected bool DoorClosed = true;

        private void Start()
        {
            _animator = transform.parent.parent.GetComponent<Animator>();
        }

        public virtual void OnGazeEnter() => TooltipGuiSocket.Display(DoorClosed
            ? $"{ToolTipOpenText} {ActivationButton}"
            : $"{ToolTipCloseText} {ActivationButton}");

        public void OnGazeExit() => TooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => ActivationButton;

        public virtual void OnPress()
        {
            if (DoorClosed)
                OpenDoor();
            else
                CloseDoor();
        }

        private void OpenDoor()
        {
            if (IsDoorInMotion()) return;

            _animator.SetBool("open", true);
            _openingDoorAudioSource.Play();

            DoorClosed = false;
        }

        private void CloseDoor()
        {
            if (IsDoorInMotion()) return;

            _closingDoorAudioSource.Play();
            _animator.SetBool("open", false);

            DoorClosed = true;
        }

        public bool IsDoorClosed()
        {
            return DoorClosed;
        }

        private bool IsDoorInMotion() => _openingDoorAudioSource.isPlaying || _closingDoorAudioSource.isPlaying;

        private void OnValidate()
        {
            Assert.AreNotEqual(ActivationButton, KeyCode.None, "Door Actiation button must not be null.");
        }
    }
}
