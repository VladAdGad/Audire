
namespace EventManagement
{
    public interface IGazable : IIteractable
    {
        void OnGazeEnter();

        void OnGazeExit();
    }
}
