namespace Luderia.Domain.Contexts.Customers.Errors;
public record FailToCommitChangesError() : InfrastructureError(nameof(FailToCommitChangesError), "Fail to persist changes");
