using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.Lock
{
    [Serializable]
    public class LockCode
    {
        [SerializeField]
        private List<string> _codeSequence;

        public void ChangeSequenceMember(int index, string value) => _codeSequence[index] = value;
        public string GetCodeAt(int index) => _codeSequence[index];
        public bool IsEqualTo(LockCode _lockCode) => _codeSequence.SequenceEqual(_lockCode._codeSequence);
    }
}