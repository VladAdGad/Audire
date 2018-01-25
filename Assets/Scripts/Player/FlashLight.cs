using UnityEngine;

namespace Player
{
    public class FlashLight : MonoBehaviour
    {
        private Light _spotLightComponent;
        private AudioSource _spotLightOnOffAudioSource;
        private bool _stateSpotLight = false;

        private void Start()
        {
            _spotLightComponent = gameObject.GetComponent<Light>();
            _spotLightOnOffAudioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.F)) return;
            _stateSpotLight = !_stateSpotLight;
            _spotLightComponent.enabled = _stateSpotLight;
            _spotLightOnOffAudioSource.Play();
        }
    }
}
