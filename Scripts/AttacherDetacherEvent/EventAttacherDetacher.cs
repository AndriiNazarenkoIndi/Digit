public class EventAttacherDetacher
{
    public delegate void EventAttachDetach();

    public void AttachDetach<T>(T eventSource, EventAttachDetach Event)
    {
        if (eventSource != null)
        {
            Event();
        }
    }
}