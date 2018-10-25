using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SentryToMail.Utils {
	public class FileCollection<T> where T : class, new() {
		private readonly DirectoryInfo _dir;

		public FileCollection(string repoPath) {
			_dir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, repoPath));
			if (!_dir.Exists) {
				_dir.Create();
			}
		}

		public Guid[] PeekAllIds() {
			return _dir.GetFiles("*.json").Select(d => Guid.Parse(Path.GetFileNameWithoutExtension(d.Name))).ToArray();
		}

		public void Delete(Guid mailId) {
			_dir.GetFiles($"{mailId}.json").Single().Delete();
		}

		public async Task Add(Guid guid, T mail) {
			string filePath = Path.Combine(_dir.FullName, guid + ".json");

			using (FileStream stream = File.OpenWrite(filePath)) {
				using (var writer = new StreamWriter(stream)) {
					JsonWriter jsonTextWriter = new JsonTextWriter(writer);
					await JObject.FromObject(mail).WriteToAsync(jsonTextWriter);
				}
			}
		}

		public async Task<T> Peek(Guid guid) {
			string filePath = Path.Combine(_dir.FullName, guid + ".json");
			using (var stream = new StreamReader(File.OpenRead(filePath))) {
				using (var reader = new JsonTextReader(stream)) {
					JObject jObject = await JObject.LoadAsync(reader);
					return jObject.ToObject<T>();
				}
			}
		}
	}
}