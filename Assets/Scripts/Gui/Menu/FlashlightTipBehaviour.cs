using Gui.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FlashlightTipBehaviour : MonoBehaviour {

    [SerializeField] private Transform _flashlightTipCanvas;
    [SerializeField] private AudioMixerSnapshot _unpaused;
    [SerializeField] private AudioMixerSnapshot _paused;
    private const int IndexFirstScene = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //FlashlightTip();
        }
    }
    // Use this for initialization
    public void StartGame()
    {
        SceneManager.LoadScene(IndexFirstScene);
    }

    public void FlashlightTip()
    {
        if (!_flashlightTipCanvas.gameObject.activeSelf)
        {
            _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
            PlayerBehaviour.PlayerOnPause(false);
            Time.timeScale = 0;
            _paused.TransitionTo(.01f);
        }
        else
        {
            _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
            PlayerBehaviour.PlayerOnPause(true);
            Time.timeScale = 1;
            _unpaused.TransitionTo(.01f);
        }
    }
 
}
