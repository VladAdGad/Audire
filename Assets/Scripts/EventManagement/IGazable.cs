namespace EventManagement
{
    public interface IGazable : IInteractable
    {
        void OnGazeEnter();

        void OnGazeExit();
    }
}