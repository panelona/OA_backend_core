using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Config
{
	[ExcludeFromCodeCoverage]
	public class AppConfig
	{
		public string ConnectionString { get; set; } = string.Empty;
	}
}
