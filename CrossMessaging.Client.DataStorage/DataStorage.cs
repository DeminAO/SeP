using CrossMessenger.Client.Infrastructure.Interfaces.Services;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossMessaging.Client.DataStorage
{
	public class TblString
	{
		[PrimaryKey, AutoIncrement]
		public Guid Id { get; set; }
		public string Value { get; set; }
	}

	public class DataStorage : IDataStorage
	{
		private readonly ICryptoService cryptoService;
		public DataStorage(ICryptoService cryptoService) => this.cryptoService = cryptoService;

		public async Task<IEnumerable<T>> GetItems<T>() where T : new()
		{
			IEnumerable<string> items;
			using (var dataBase = new SQLiteConnection(typeof(T).Name))
			{
				dataBase.CreateTable<TblString>();
				items = dataBase.Table<TblString>().Select(x => x.Value).ToList();
			}
			List<T> data = new List<T>();
			foreach (var item in items)
			{
				var decrypted = await cryptoService.DecryptStringAES(item);
				data.Add(JsonConvert.DeserializeObject<T>(decrypted));
			}
			return data;
		}

		public async Task PutItems<T>(IEnumerable<T> items)
		{
			var serialized = items.Select(x => JsonConvert.SerializeObject(x));
			using var dataBase = new SQLiteConnection(typeof(T).Name);
			dataBase.CreateTable<TblString>();
			foreach (var item in serialized)
			{
				var encrypted = await cryptoService.EncryptStringAES(item);
				dataBase.Insert(new TblString { Value = encrypted });
			}
		}
	}
}
