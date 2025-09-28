// To work in cooperative with UserSessionTracking
using System.Collections.Generic;

public class AppState
{
    public string UserName { get; set; }
    public bool IsRegistered { get; set; }
    public HashSet<string> AttendedEvents { get; set; } = new();

    public event Action OnChange;

    public void SetUser(string name)
    {
        UserName = name;
        NotifyStateChanged();
    }

    public void SetRegistration(bool registered)
    {
        IsRegistered = registered;
        NotifyStateChanged();
    }

    public void MarkAttendance(string eventName)
    {
        AttendedEvents.Add(eventName);
        NotifyStateChanged();
    }

    public bool HasAttended(string eventName) => AttendedEvents.Contains(eventName);

    private void NotifyStateChanged() => OnChange?.Invoke();
}
