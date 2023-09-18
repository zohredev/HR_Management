using Hanssens.Net;
using HR_Managment.MVC.Contracts;

namespace HR_Managment.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _storage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR_ManageMentGMT"
            };
            _storage = new LocalStorage(config);
        }
        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            //moratab sazi mishe ba persist
            _storage.Persist();
        }
    }
}
