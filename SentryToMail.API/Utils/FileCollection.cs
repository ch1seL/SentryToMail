using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace SentryToMail.API.Utils {
	public class FileCollection<T> where T : class, ISerializable, new() {
		private static readonly Encoding Encoding = Encoding.Unicode;
		private readonly string _filePath;
		private T _collection;

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
			byte[] file = File.ReadAllBytes(_filePath);
			_collection = JsonConvert.DeserializeObject<T>(Encoding.GetString(file)) ?? _collection;

			TR result = func(_collection);

			file = Encoding.GetBytes(JsonConvert.SerializeObject(_collection, Formatting.Indented));
			File.WriteAllBytes(_filePath, file);

			return result;
		}

		public T PeekAll() {
			byte[] file = File.ReadAllBytes(_filePath);
			_collection = JsonConvert.DeserializeObject<T>(Encoding.GetString(file)) ?? _collection;
			return _collection;
		}
	}
}