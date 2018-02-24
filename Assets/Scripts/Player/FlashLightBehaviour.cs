using UnityEngine;

namespace Player
{
    public class FlashLightBehaviour : MonoBehaviour
    {
        private Light _spotLightComponent;
        private AudioSource _spotLightOnOffAudioSource;
        private bool _stateSpotLight;

        private void Start()
        {
            _spotLightComponent = gameObject.GetComponent<Light>();
            _spotLightOnOffAudioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                _stateSpotLight = !_stateSpotLight;
                _spotLightComponent.enabled = _stateSpotLight;
                _spotLightOnOffAudioSource.Play();
            }
        }
    }
}
