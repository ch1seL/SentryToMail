using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SentryToMail.Utils {
	public class FileCollection<T> where T : class, ISerializable, new() {
		private readonly string _filePath;
		private T _collection;
		private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
			{ Formatting = Formatting.Indented };

		public FileCollection(string filePath) {
			_filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
			if (File.Exists(_filePath)) {
				return;
			}
			string dirPath = Path.GetDirectoryName(_filePath) ?? throw new InvalidOperationException($"Directory name of file {_filePath} is null");
			if (!Directory.Exists(dirPath)) {
				Directory.CreateDirectory(dirPath);
			}
			File.Create(_filePath).Close();
		}

		public Task<T> PeekAll() {
			return ReadJsonFromFile(_filePath);
		}

		public async Task<TR> UpdateAsync<TR>(Func<T, TR> func) {
			_collection = await ReadJsonFromFile(_filePath);

			TR result = func(_collection);

			await WriteJsonToFile(_filePath, _collection);

			return result;
		}

		private Task<T> ReadJsonFromFile(string filePath) {
			return Task.Run(() => {
				using (FileStream stream = File.OpenRead(filePath)) {
					using (var reader = new StreamReader(stream)) {
						JsonSerializer serializer = JsonSerializer.CreateDefault();
						var jsonTextReader = new JsonTextReader(reader);
						return serializer.Deserialize<T>(jsonTextReader) ?? new T();
					}
				}
			});
		}

		private Task WriteJsonToFile(string filePath, T obj) {
			return Task.Run(() => {
				using (FileStream stream = File.OpenWrite(filePath)) {
					using (var reader = new StreamWriter(stream)) {
						JsonSerializer serializer = JsonSerializer.Create(_serializerSettings);
						var jsonTextWriter = new JsonTextWriter(reader);
						serializer.Serialize(jsonTextWriter, obj);
						jsonTextWriter.Flush();
					}
				}
			});
		}
	}
}