using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces.Services
{
	public interface ICryptoService
	{
		Task<string> DecryptStringAES(string cipherText);
		Task<string> EncryptStringAES(string plainText);
	}
}