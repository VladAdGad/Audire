using System.Collections;
using NUnit.Framework;
using Player;
using SceneMenager;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Vlad.Scripts
{
    public class PlayerDeathBehaviour : MonoBehaviour
    {
        [SerializeField] private string _nameOfTheDeathAnimation = "deadAnimation";
        [SerializeField] private GameObject _deathCauseCanvas;
        private const float WaitBeforeReloadSceneSeconds = 5;
        private const float WaitBeforeFaideSeconds = 1.5f;
        private static string _deathCauseText = "You died";
        private Animator _deathAnimation;
        private Image _faidingImage;

        private void Start()
        {
            _deathAnimation = GetComponent<Animator>();
            _faidingImage = _deathCauseCanvas.GetComponent<Image>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(ProcessOfDeath());
            }
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
            _faidingImage.CrossFadeAlpha(1, 5, false);
        }

        public static void ChangeTextOfDeathCause(string deathCause)
        {
            _deathCauseText = deathCause;
        }

        private void OnValidate()
        {
            Assert.NotNull(_deathCauseCanvas);
        }
    }
}