using System.Collections;
using UnityEngine;

public class PickupNote : MonoBehaviour
{
    public bool hasCollided = false;

    //Maximum Distance you Can Pick Up A Book
    public float maxDistance = 100f;

    //Your Custom GUI Skin with the Margins, Padding, Align, And Texture all up to you :)
    public GUISkin skin;

    //Are we currently reading a note?
    private bool readingNote = false;

    //The text of the note we last read
    private string noteText;

    private Camera m_camera;

    public GameObject Sound;

    void Start()
    {
        //Start the input check loop
        m_camera = Camera.main;
        StartCoroutine(CheckForInput());
    }

    private IEnumerator CheckForInput()
    {
        // Keep Updating
        while (true)
        {
            //If the 'F' was pressed and not reading a note check for a note, else stop reading
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (readingNote)
                {
                    m_camera.enabled = true;
                    readingNote = false;
                }
                else
                {
                    CheckForNote();
                }
            }

            //Wait One Frame Before Continuing Loop
            yield return null;
        }
    }

    private void CheckForNote()
    {
        //A ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
        RaycastHit hit;

        //Did we hit something?
        //Was the object we hit a note?
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.GetComponent<Note>())
        {
            //Get text of note and set reading to true
            noteText = hit.transform.GetComponent<Note>().Text;
            //Destroy (data.transform.gameObject);
            readingNote = true;
            m_camera.enabled = false;
            Sound.GetComponent<AudioSource>().Play();
        }
    }

    private void OnGUI()
    {
        if (skin)
        {
            GUI.skin = skin;
        }

        //Are we reading a note? If so draw it.
        if (readingNote)
        {
            //Draw the note on screen, Set And Change the GUI Style To Make the Text Appear The Way you Like (Even on an image background like paper)
            GUI.Box(
                new Rect(Screen.width / 2 - Screen.width / 6, Screen.height / 24, Screen.width / 3,
                    Screen.height - Screen.height / 18), noteText);
        }
    }
}