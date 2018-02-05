using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class ButtonNumberChanger : MonoBehaviour
    {
        private static readonly IDictionary<string, string> NextNumber = Enumerable
            .Range(0, 10)
            .ToDictionary(x => x.ToString(), x => ((x+1) % 10).ToString());

        private Text _text;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
            GetComponent<Button>().onClick.AddListener(() => _text.text = NextNumber[_text.text]);
        }
    }
}
