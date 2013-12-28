namespace ResponseChecker
{
    /// <summary>
    /// Enumeration of the different statuses a check can have
    /// </summary>
    public enum CheckStatus
    {
        NotYetRun,
        InProgress,
        Failed,
        Succeeded,
        ExceptionEncountered
    }
}
