using UnityEngine;
using System.Collections;

public class PaintingLook : MonoBehaviour
{
    bool near = false;

    private bool readingNote = false;
    public Transform player;
    private Camera m_camera;
    public Texture image;
    public GUISkin skin;

    void Start()
    {
        StartCoroutine(CheckForInput());
        m_camera = Camera.main;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            near = true;
        }
        if (Vector3.Distance(transform.position, player.position) > 1.5f)
        {
            near = false;
        }
    }

    private IEnumerator CheckForInput()
    {
        //Keep Updating
        while (true)
        {
            //If the 'F' was pressed and not reading a note check for a note, else stop reading
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!readingNote)
                {
                    CheckForNote();
                }
                else
                {
                    near = false;
                    m_camera.enabled = true;
                    readingNote = false;
                }
            }


            //Wait One Frame Before Continuing Loop
            yield return null;
        }
    }

    private void CheckForNote()
    {
        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            near = false;
            readingNote = true;
            m_camera.enabled = false;
        }
    }


    void OnGUI()
    {
        if (readingNote)
        {
            GUI.DrawTexture(
                new Rect(Screen.width - Screen.width / 2 - Screen.width / 7, Screen.height / 24, image.width,
                    image.height), image);
        }


        if (near == true)
        {
            if (skin)
                GUI.skin = skin;

            GUI.TextArea(new Rect(Screen.width / 2 - Screen.width / 6, Screen.height / 2 + Screen.height / 4,
                Screen.width / 3,
                Screen.width / 2 - 2 * Screen.width / 5), "Press F to to look closer");
        }
    }
}