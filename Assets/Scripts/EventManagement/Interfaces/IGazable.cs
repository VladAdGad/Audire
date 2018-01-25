namespace EventManagement.Interfaces
{
    public interface IGazable : IInteractable
    {
        void OnGazeEnter();

        void OnGazeExit();
    }
}
