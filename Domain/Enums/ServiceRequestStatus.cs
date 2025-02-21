namespace ServiceCenter.Domain.Enums
{
    /// <summary>
    /// Represents the status of a service request.
    /// </summary>
    /// <remarks>
    /// Possible values include New, InProgress, and Completed.
    /// </remarks>
    public enum ServiceRequestStatus
    {
        New = 0,
        InProgress = 1,
        Completed = 2
    }
}
