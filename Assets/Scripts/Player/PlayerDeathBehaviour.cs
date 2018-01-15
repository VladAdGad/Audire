using System.Collections;
using SceneMenager;
using UnityEngine;
using UnityEngine.Assertions;
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

        public IEnumerator ProcessOfDeath()
        {
            PlayerBehaviour.PlayerDisable();
            StartPlayAnimation();
            yield return new WaitForSeconds(WaitBeforeFaideSeconds);
            StartFaiding();
            ShowTextOfDeathCause();
            yield return new WaitForSeconds(WaitBeforeReloadSceneSeconds);
            LoadScene.ReloadScene();
        }
        
        public IEnumerator ProcessOfDeath(float secondsBeforeDeath)
        {
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

        public void ChangeTextOfDeathCause(string deathCause)
        {
            _deathCauseCanvas.GetComponentInChildren<Text>().text = deathCause;
        }

//TODO why there is null but it isn't?        
//        private void OnValidate()
//        {
//            Assert.IsNotNull(_deathCauseCanvas);
//        }
    }
}
