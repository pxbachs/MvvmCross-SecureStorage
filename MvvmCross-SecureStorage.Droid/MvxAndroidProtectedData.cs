using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;
using Android.Content;
using Android.App;

namespace FSB.MvvmCross.Plugins.SecureStorage.Droid
{
	public class MvxAndroidProtectedData : IMvxProtectedData
	{
		private readonly ISharedPreferences _preferences;

		public MvxAndroidProtectedData()
		{
			_preferences = Application.Context.GetSharedPreferences(Application.Context.PackageName + ".SecureStorage",
				FileCreationMode.Private);
		}

		public void Protect(string key, string value)
		{
			var editor = _preferences.Edit();
			editor.PutString(key, value);
			editor.Commit();
		}

		public string Unprotect(string key)
		{
			try
			{
				return _preferences.GetString(key, null);
			}
			catch
			{
				return null;
			}
		}

		public void Remove(string key)
		{
			if (_preferences.Contains(key))
			{
				var editor = _preferences.Edit();
				editor.Remove(key);
				editor.Commit();
			}
		}
	}

}

