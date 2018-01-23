namespace Triggers
{
    public class ActivateOnAPassiveTriggered : APassiveTriggerable
    {
        public override void OnTrigger() => gameObject.SetActive(true);
    }
}
