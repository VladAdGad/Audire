using UnityEngine;

namespace Utilities
{
    public class DeleteObject : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
