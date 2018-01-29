using System.Collections;
using SceneMenager;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerDeathBehaviour : MonoBehaviour
    {
        [SerializeField] private string _nameOfTheDeathAnimation = "deadAnimation";
        [SerializeField] private GameObject _deathCauseCanvas;
        private const int WaitBeforeReloadSceneSeconds = 5;
        private const float WaitBeforeFaide = 1.5f;
        private const float WaitBeforDisableScreamer = 0.2f;
        private AudioSource _deathRattle;
        private Animator _deathAnimation;
        private Image _faidingImage;
        private bool _isPlayerDie;
        private Text _deathText;

        private void Start()
        {
            _deathText = _deathCauseCanvas.GetComponentInChildren<Text>();
            _faidingImage = _deathCauseCanvas.GetComponent<Image>();
            _deathAnimation = GetComponent<Animator>();
            _deathRattle = GetComponent<AudioSource>();
        }

        private void StartPlayAnimation()
        {
            _deathAnimation.enabled = true;
            _deathAnimation.Play(_nameOfTheDeathAnimation);
        }

        private IEnumerator ProcessOfDeath(string deathText)
        {
            if (_isPlayerDie) yield break;
            SetPlayerIsDie();
            ChangeTextOfDeathCause(deathText);
            StartCoroutine(StartPlayerDeath());
        }

        private IEnumerator ProcessOfDeath(float secondsBeforeDeath, string deathText)
        {
            if (_isPlayerDie) yield break;
            SetPlayerIsDie();
            yield return new WaitForSeconds(secondsBeforeDeath);
            ChangeTextOfDeathCause(deathText);
            StartCoroutine(StartPlayerDeath());
        }
        
        private IEnumerator ProcessOfDeath(string deathText, Image ghostImage, AudioSource screamSoundaudioSource)
        {
            if (_isPlayerDie) yield break;
            SetPlayerIsDie();
            ChangeTextOfDeathCause(deathText);
            ghostImage.enabled = true;
            screamSoundaudioSource.Play();
            yield return new WaitForSeconds(WaitBeforDisableScreamer);
            ghostImage.enabled = false;
            StartCoroutine(StartPlayerDeath());
        }

        private IEnumerator StartPlayerDeath()
        {
            _deathRattle.Play();
            PlayerBehaviour.PlayerDisable();
            StartPlayAnimation();
            yield return new WaitForSeconds(WaitBeforeFaide);
            StartFaiding();
            ShowTextOfDeathCause();
            yield return new WaitForSeconds(WaitBeforeReloadSceneSeconds);
            LoadScene.ReloadScene();
        }

        private void ShowTextOfDeathCause()
        {
            _deathText.enabled = true;
        }

        private void StartFaiding()
        {
            //TODO WHY //https://stackoverflow.com/questions/42330509/crossfadealpha-not-working ?
            Color fixedColor = _faidingImage.color;
            fixedColor.a = 1;
            _faidingImage.color = fixedColor;
            _faidingImage.CrossFadeAlpha(0f, 0f, true);
            _faidingImage.CrossFadeAlpha(1, 3, false);
        }

        private void ChangeTextOfDeathCause(string deathCause)
        {
            _deathText.text = deathCause;
        }

        private void SetPlayerIsDie()
        {
            _isPlayerDie = true;
        }

        public void StartProcessOfDeath(float secondsBeforeDeath, string deathText)
        {
            StartCoroutine(secondsBeforeDeath != .0f
                ? ProcessOfDeath(secondsBeforeDeath, deathText)
                : ProcessOfDeath(deathText));
        }
        
        public void StartProcessOfDeath(string deathText, Image ghostImage, AudioSource screamSoundaudioSource)
        {
            StartCoroutine(ProcessOfDeath(deathText, ghostImage, screamSoundaudioSource));
        }
    }
}
