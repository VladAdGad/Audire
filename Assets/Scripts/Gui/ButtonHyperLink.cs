using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Gui
{
    public class ButtonHyperLink : MonoBehaviour
    {
        [SerializeField] private string _hyperLink;

        private void Awake() => GetComponent<Button>().onClick.AddListener(() => Application.OpenURL(_hyperLink));

        private void OnValidate() => Assert.IsNotNull(_hyperLink);
    }
}
