using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.MarkAsSuspicious;

public sealed record MarkTransactionsAsSuspiciousCommand(long Id) : IRequest;
