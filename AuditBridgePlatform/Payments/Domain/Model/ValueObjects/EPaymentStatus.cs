namespace AuditBridgePlatform.Payments.Domain.Model.ValueObjects;

public enum EPaymentStatus
{
    Paid,
    Unpaid,
    Failed,
    Refunded
}