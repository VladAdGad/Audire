using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts
{
    public static class NumberRollingUtility
    {
        private static readonly IDictionary<string, string> NextNumber = NumbersWith(x => x + 1);
        private static readonly IDictionary<string, string> PreviousNumber = NumbersWith(x => x + 9);
        private static readonly IDictionary<PointerEventData.InputButton, Func<string, string>> DrumRollingMap = CreateDrumRollingMap();
        
        private static IDictionary<string, string> NumbersWith(Func<int, int> func) =>
            Enumerable
                .Range(0, 10)
                .ToDictionary(x => x.ToString(), x => (func(x) % 10).ToString());


        private static IDictionary<PointerEventData.InputButton, Func<string, string>> CreateDrumRollingMap()
        {
            IDictionary<PointerEventData.InputButton, Func<string, string>> map = new Dictionary<PointerEventData.InputButton, Func<string, string>>();
            map.Add(PointerEventData.InputButton.Left, number => NextNumber[number]);
            map.Add(PointerEventData.InputButton.Right, number => PreviousNumber[number]);

            return map;
        }

        public static string RollNextNumber(PointerEventData.InputButton button, string previous) => DrumRollingMap[button].Invoke(previous);
    }
}