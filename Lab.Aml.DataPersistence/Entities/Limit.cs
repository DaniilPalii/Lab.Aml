using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.DataPersistence.Entities;

public class Limit
{
	[Key]
	public long? Id { get; set; }

	[Required]
	public Currency? Currency { get; set; }

	[Required]
	public DateTime? CreationDate { get; set; }

	/// <summary><see cref="Transaction"/>s exceeding this amount will be marked as suspicious.</summary>
	[Required]
	[Column(TypeName = "decimal(18,4)")]
	public decimal? Amount { get; set; }

	/// <summary>
	/// If there this many <see cref="Transaction"/>s for <see cref="Customer"/> in single <see cref="Range"/>
	/// then they will be marked as suspicious.
	/// </summary>
	[Required]
	public int? Count { get; set; }

	/// <summary>
	/// If there as many <see cref="Transaction"/>s as in <see cref="Count"/> for <see cref="Customer"/> in single range
	/// then they will be marked as suspicious.
	/// </summary>
	[Required]
	public TimeSpan? Range { get; set; }

	public Domain.Limits.Limit ToDomainValue()
	{
		return new(
			Id: Id!.Value,
			Currency: Currency!.Value,
			CreationDate: CreationDate!.Value,
			Amount: Amount!.Value,
			Count: Count!.Value,
			Range: Range!.Value);
	}
}
