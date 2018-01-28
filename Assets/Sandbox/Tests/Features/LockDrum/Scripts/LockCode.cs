using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts
{
    [Serializable]
    public class LockCode
    {
        [SerializeField]
        private List<string> _codeSequence;

        private LockCode(IEnumerable<string> codeSequence)
        {
            _codeSequence = new List<string>(codeSequence);
        }

        public LockCode ChangeSequenceMember(int index, string value)
        {
            string[] newSequence = _codeSequence.ToArray();
            newSequence[index] = value;
            return new LockCode(newSequence);
        }

        public string GetCodeAt(int index) => _codeSequence[index];

        public bool IsEqualTo(LockCode _lockCode) => _codeSequence.All(index => _lockCode._codeSequence.Contains(index)) && _lockCode._codeSequence.Count == _codeSequence.Count;

    }
}