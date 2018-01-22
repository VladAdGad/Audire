using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Utilities;

namespace Assets.Sandbox.Tests.PianoPlay.Scripts
{
    public class PianoKeySequenceTriggerer : MonoBehaviour
    {
        [SerializeField] private List<KeyCode> _keySequence;
        [SerializeField] private int _secondsTillSequenceWillReset = 4;
        [SerializeField] private APassiveTriggerable _triggerOnSuccess;

        private int _nextKeyIndex;
        private Coroutine _squenceResetCorutine;

        private void Start() => _nextKeyIndex = 0;

        public void OnPianoKeyPressed(KeyCode keyCode)
        {
            if (IsProgressSucceeded()) return;

            if (IsCurrentKeyEqualTo(keyCode))
            {
                StopResetProgressCorutine();
                MoveToNextKey();

                if (IsProgressSucceeded())
                    _triggerOnSuccess.OnTrigger();
                else
                    StartResetCorutine();
            }
            else
            {
                StopResetProgressCorutine();
                ResetProggress();
            }
        }

        private bool IsProgressSucceeded() => _nextKeyIndex == _keySequence.Count;
        private bool IsCurrentKeyEqualTo(KeyCode keyCode) => _keySequence[_nextKeyIndex].Equals(keyCode);
        private void MoveToNextKey() => _nextKeyIndex++;

        private void StartResetCorutine() => _squenceResetCorutine = StartCoroutine(CreateResetProgressCorutine());

        private IEnumerator CreateResetProgressCorutine()
        {
            yield return new WaitForSeconds(_secondsTillSequenceWillReset);
            ResetProggress();
        }

        private void ResetProggress() => _nextKeyIndex = 0;
    

        private void StopResetProgressCorutine() =>
            Optional<Coroutine>
                .Of(_squenceResetCorutine)
                .IfPresent(StopCoroutine);

        private void OnValidate()
        {
            Assert.True(_keySequence.Count > 0, "Piano Key Sequence must contain at least one key!");
        }
    }
}