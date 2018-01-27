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
        private const float WaitBeforeReloadSceneSeconds = 5;
        private const float WaitBeforeFaideSeconds = 1.5f;
        private AudioSource _deathRattle;
        private Animator _deathAnimation;
        private Image _faidingImage;
        private bool _isPlayerDie;

        private void Start()
        {
            _faidingImage = _deathCauseCanvas.GetComponent<Image>();
            _deathAnimation = GetComponent<Animator>();
            _deathRattle = GetComponent<AudioSource>();
        }

        private void StartPlayAnimation()
        {
            _deathAnimation.enabled = true;
            _deathAnimation.Play(_nameOfTheDeathAnimation);
        }

        private IEnumerator ProcessOfDeath()
        {
            if (_isPlayerDie) yield break;
            SetPlayerIsDie();
            _deathRattle.Play();
            PlayerBehaviour.PlayerDisable();
            StartPlayAnimation();
            yield return new WaitForSeconds(WaitBeforeFaideSeconds);
            StartFaiding();
            ShowTextOfDeathCause();
            yield return new WaitForSeconds(WaitBeforeReloadSceneSeconds);
            LoadScene.ReloadScene();
        }

        private IEnumerator ProcessOfDeath(float secondsBeforeDeath)
        {
            if (_isPlayerDie) yield break;
            SetPlayerIsDie();
            yield return new WaitForSeconds(secondsBeforeDeath);
            _deathRattle.Play();
            PlayerBehaviour.PlayerDisable();
            StartPlayAnimation();
            yield return new WaitForSeconds(WaitBeforeFaideSeconds);
            StartFaiding();
            ShowTextOfDeathCause();
            yield return new WaitForSeconds(WaitBeforeReloadSceneSeconds);
            LoadScene.ReloadScene();
        }

        private void ShowTextOfDeathCause()
        {
            _deathCauseCanvas.GetComponentInChildren<Text>().enabled = true;
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
            _deathCauseCanvas.GetComponentInChildren<Text>().text = deathCause;
        }

        private void SetPlayerIsDie()
        {
            _isPlayerDie = !_isPlayerDie;
        }

        public void StartProcessOfDeath(float secondsBeforeDeath, string deathText)
        {
            ChangeTextOfDeathCause(deathText);
            StartCoroutine(secondsBeforeDeath != .0f
                ? ProcessOfDeath(secondsBeforeDeath)
                : ProcessOfDeath());
        }
    }
}
