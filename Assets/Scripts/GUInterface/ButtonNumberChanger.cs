using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GUInterface
{
    public class ButtonNumberChanger : MonoBehaviour
    {
        private static readonly IDictionary<string, string> NextNumber = NumbersWith(x => x + 1);
//        private static readonly IDictionary<string, string> PreviousNumber = NumbersWith(x => x + 9);

        private Text _text;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
            GetComponent<Button>().onClick.AddListener(() => _text.text = NextNumber[_text.text]);
        }

        private static IDictionary<string, string> NumbersWith(Func<int, int> func)
        {
            return Enumerable
                .Range(0, 10)
                .ToDictionary(x => x.ToString(), x => (func(x) % 10).ToString());
        }
    }
}