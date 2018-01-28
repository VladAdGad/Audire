using UnityEngine;

namespace Utilities
{
    public class ObjectsBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        public void Destroy()
        {
            Destroy(_gameObject);
        }

        public void DisableObject()
        {
            _gameObject.SetActive(false);
        }
    }
}
