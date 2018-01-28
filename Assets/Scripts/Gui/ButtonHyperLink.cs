using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class ButtonHyperLink : MonoBehaviour
    {
        [SerializeField] private string _hyperLink;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => Application.OpenURL(_hyperLink));
        }
    }
}
