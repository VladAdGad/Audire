using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneMenager
{
    public class TextColorBehaviuor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Text _text;
        [SerializeField] private Color _enterColor = Color.red;
        [SerializeField] private Color _exitColor = Color.white;
        
        private void Start()
        {
            _text = GetComponent<Text>();
            _text.color = _exitColor;
        }

        public void OnPointerEnter(PointerEventData eventData) => _text.color = _enterColor;

        public void OnPointerExit(PointerEventData eventData) => _text.color = _exitColor;

        private void OnValidate()
        {
            Assert.IsNotNull(_text);
        }
    }
}
