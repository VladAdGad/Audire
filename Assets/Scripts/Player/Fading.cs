using UnityEngine;
using UnityEngine.Assertions;

namespace Player
{
    public class Fading : MonoBehaviour
    {
        // the texture that will overlay the screen. This can be a black image or a loading graphic
        [SerializeField] private Texture2D _fadeOutTexture;

        // the fading speed
        [SerializeField] private float _fadeSpeed = 0.8f;

        // the texture's order in the draw hierarchy: a low number means it renders on top
        private const int _drawDepth = -1000;

        private float _alpha = 1.0f; // the texture's alpha value between 0 and 1
        private int _fadeDir = -1; // the direction to fade: in = -1 or out = 1

        private void OnGUI()
        {
            // fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
            _alpha += _fadeDir * _fadeSpeed * Time.deltaTime;
            // force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
            _alpha = Mathf.Clamp01(_alpha);

            // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
            GUI.depth = _drawDepth; // make the black texture render on top (drawn last)
            // draw the texture to fit the entire screen area
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _fadeOutTexture);
        }

        // sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
        public float BeginFade(int direction)
        {
            _fadeDir = direction;
            return _fadeSpeed;
        }

        public void StartFaiding() => gameObject.GetComponent<Fading>().BeginFade(1);

        private void OnValidate() => Assert.IsNotNull(_fadeOutTexture);
    }
}
