namespace BaseLib.Logging
{
    /// <summary>
    /// IHasLogSeverity
    /// </summary>
    public interface IHasLogSeverity
    {
        LogSeverity Severity { get; set; }
    }
}