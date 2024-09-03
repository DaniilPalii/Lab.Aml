using Lab.Aml.Domain.Limits;
using Lab.Aml.Domain.Limits.Queries.GetLatest;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Verify;
using MediatR;
using NSubstitute;

namespace Lab.Aml.Tests.DomainUnitTests;

[TestFixture]
public class VerifyTransactionsCommandHandlerTests
{
	[SetUp]
	public void Setup()
	{
		mediator = Substitute.For<IMediator>();
		transactionRepository = Substitute.For<IVerifyTransactionsRepository>();
		handler = new VerifyTransactionsCommandHandler(transactionRepository, mediator);
	}

	[Test]
	public async Task Handle_TransactionAmountExceedsLimit_ShouldMarkAsSuspicious()
	{
		// Arrange
		var limit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 10,
			Range: TimeSpan.FromHours(1)
		);

		var transaction = new Transaction(
			Id: 1,
			Amount: 1500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 123
		);

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([limit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([transaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(transaction.Id, previousOrNextTransactionsCount: 9, Arg.Any<CancellationToken>())
			.Returns([]);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsSuspicious(transaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	[Test]
	public async Task Handle_TransactionAmountWithinLimit_ShouldMarkAsNotSuspicious()
	{
		// Arrange
		var limit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 10,
			Range: TimeSpan.FromHours(1)
		);

		var transaction = new Transaction(
			Id: 1,
			Amount: 500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 123
		);

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([limit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([transaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(transaction.Id, previousOrNextTransactionsCount: 9, Arg.Any<CancellationToken>())
			.Returns([]);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsNotSuspicious(transaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	[Test]
	public async Task Handle_TransactionAmountExceedsLimitOnlyInOtherCurrency_ShouldNotMarkAsSuspicious()
	{
		// Arrange
		var usdLimit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 10_000,
			Count: 10,
			Range: TimeSpan.FromHours(1)
		);

		var eurLimit = new Limit(
			Id: 1,
			Currency: Currency.EUR,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 10,
			Range: TimeSpan.FromHours(1)
		);

		var usdTransaction = new Transaction(
			Id: 1,
			Amount: 1500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 123
		);

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([usdLimit, eurLimit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([usdTransaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(usdTransaction.Id, previousOrNextTransactionsCount: 9, Arg.Any<CancellationToken>())
			.Returns([]);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsNotSuspicious(usdTransaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	[Test]
	public async Task Handle_TooFrequentTransactions_ShouldMarkAsSuspicious()
	{
		// Arrange
		var limit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 3,
			Range: TimeSpan.FromMinutes(10)
		);

		var transaction = new Transaction(
			Id: 1,
			Amount: 500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 123
		);

		var transactionWithPreviousTransactions = new[]
		{
			new Transaction(
				Id: 1,
				Amount: 500,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow,
				Description: "Test Transaction",
				CustomerId: 123),

			new Transaction(
				Id: 2,
				Amount: 300,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-5),
				Description: "Test Transaction 2",
				CustomerId: 123),

			new Transaction(
				Id: 3,
				Amount: 400,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-3),
				Description: "Test Transaction 3",
				CustomerId: 123)
		};

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([limit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([transaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(transaction.Id, previousOrNextTransactionsCount: 2, Arg.Any<CancellationToken>())
			.Returns(transactionWithPreviousTransactions);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsSuspicious(transaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	[Test]
	public async Task Handle_NotTooFrequentTransactionsFromMultipleCustomers_ShouldNotMarkAsSuspicious()
	{
		// Arrange
		var limit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 3,
			Range: TimeSpan.FromMinutes(10)
		);

		var transaction = new Transaction(
			Id: 1,
			Amount: 500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 11
		);

		var transactionWithPreviousTransactions = new[]
		{
			new Transaction(
				Id: 1,
				Amount: 500,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow,
				Description: "Test Transaction",
				CustomerId: 11),

			new Transaction(
				Id: 2,
				Amount: 300,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-5),
				Description: "Test Transaction 2",
				CustomerId: 11),

			new Transaction(
				Id: 3,
				Amount: 400,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-3),
				Description: "Test Transaction 3",
				CustomerId: 22)
		};

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([limit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([transaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(transaction.Id, previousOrNextTransactionsCount: 2, Arg.Any<CancellationToken>())
			.Returns(transactionWithPreviousTransactions);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsSuspicious(transaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	[Test]
	public async Task Handle_TransactionsNotTooFrequent_ShouldMarkAsNotSuspicious()
	{
		// Arrange
		var limit = new Limit(
			Id: 1,
			Currency: Currency.USD,
			CreationDate: DateTime.UtcNow,
			Amount: 1000,
			Count: 3,
			Range: TimeSpan.FromMinutes(1)
		);

		var transaction = new Transaction(
			Id: 1,
			Amount: 500,
			Currency: Currency.USD,
			TransactionType: TransactionType.Deposit,
			CreationDate: DateTime.UtcNow,
			Description: "Test Transaction",
			CustomerId: 123
		);

		var previousTransactions = new[]
		{
			new Transaction(
				Id: 2,
				Amount: 300,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-5),
				Description: "Test Transaction 2",
				CustomerId: 123),

			new Transaction(
				Id: 3,
				Amount: 400,
				Currency: Currency.USD,
				TransactionType: TransactionType.Deposit,
				CreationDate: DateTime.UtcNow.AddMinutes(-3),
				Description: "Test Transaction 3",
				CustomerId: 123)
		};

		mediator.Send(Arg.Any<GetLatestLimitsQuery>(), Arg.Any<CancellationToken>()).Returns([limit]);
		transactionRepository.GetNotVerifiedAsync(Arg.Any<CancellationToken>()).Returns([transaction]);
		transactionRepository.GetByIdWithPreviousAndNextAsync(transaction.Id, previousOrNextTransactionsCount: 2, Arg.Any<CancellationToken>())
			.Returns(previousTransactions);

		// Act
		await handler.Handle(new VerifyTransactionsCommand(), CancellationToken.None);

		// Assert
		transactionRepository.Received(1).MarkAsNotSuspicious(transaction.Id);
		await transactionRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
	}

	private IMediator mediator;
	private IVerifyTransactionsRepository transactionRepository;
	private VerifyTransactionsCommandHandler handler;
}
