public abstract record DomainError(string Type, string Message) : Error;
