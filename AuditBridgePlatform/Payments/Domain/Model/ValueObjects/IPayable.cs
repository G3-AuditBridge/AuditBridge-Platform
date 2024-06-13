namespace AuditBridgePlatform.Payments.Domain.Model.ValueObjects;

public interface IPayable
{
    void SentToPay();
    void Reject();
    void ApproveAndNotify();

}