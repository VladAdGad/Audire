using System.Collections;
using EventManagement;
using UnityEngine;
using Utilities;

public class DoorObsticleBehaviuor : MonoBehaviour, IPressable
{
    [SerializeField] private KeyCode activationKeyCode = KeyCode.E;

    private IEnumerator currentRotationCorutine;
    private bool closing = false;

    public KeyCode ActivationKeyCode()
    {
        return activationKeyCode;
    }

    public void OnPress()
    {
        ChangeMovingState();
    }

    private void ChangeMovingState()
    {
        stopRunningRotationCorutine();

        if (closing)
            startOpeningRotation();
        else
            startClosingRotation();
    }

    private void stopRunningRotationCorutine() =>
        Optional<IEnumerator>
            .Of(currentRotationCorutine)
            .IfPresent(StopCoroutine);

    private void startOpeningRotation()
    {
        closing = false;
        currentRotationCorutine = Rotate(Vector3.up, 8);
        StartCoroutine(currentRotationCorutine);
    }

    private void startClosingRotation()
    {
        closing = true;
        currentRotationCorutine = Rotate(Vector3.right, 8);
        StartCoroutine(currentRotationCorutine);
    }

    IEnumerator Rotate(Vector3 destinationAngles, float speed)
    {
        while (transform.forward != destinationAngles - transform.position)
        {
            Vector3 targetDir = destinationAngles - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            yield return null;
        }
    }
}