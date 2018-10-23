using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace SentryToMail.Utils {
	public class FileCollection<T> where T : class, ISerializable, new() {
		private readonly string _filePath;
		private T _collection;
		private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
			{ Formatting = Formatting.Indented };

		public FileCollection(string filePath, T collection = null) {
			_collection = collection ?? new T();
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

		public TR Update<TR>(Func<T, TR> func) {
			_collection = ReadJsonFromFile(_filePath) ?? _collection;

			TR result = func(_collection);

			WriteJsonToFile(_filePath, _collection);

			return result;
		}

		private T ReadJsonFromFile(string filePath) {
			using (FileStream stream = File.OpenRead(filePath)) {
				using (var reader = new StreamReader(stream)) {
					JsonSerializer serializer = JsonSerializer.CreateDefault();
					var jsonTextReader = new JsonTextReader(reader);
					return serializer.Deserialize<T>(jsonTextReader);
				}
			}
		}

		private void WriteJsonToFile(string filePath, T obj) {
			using (FileStream stream = File.OpenWrite(filePath)) {
				using (var reader = new StreamWriter(stream)) {
					JsonSerializer serializer = JsonSerializer.Create(_serializerSettings);
					var jsonTextWriter = new JsonTextWriter(reader);
					serializer.Serialize(jsonTextWriter, obj);
					jsonTextWriter.Flush();
				}
			}
		}

		public T PeekAll() {
			T jsonFromFile = ReadJsonFromFile(_filePath);
			_collection = jsonFromFile ?? _collection;
			return _collection;
		}
	}
}