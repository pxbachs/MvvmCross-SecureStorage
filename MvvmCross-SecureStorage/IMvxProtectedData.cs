using System;

namespace FSB.MvvmCross.Plugins.SecureStorage
{

	public interface IMvxProtectedData
	{
		void Protect(string key, string value);
		string Unprotect(string key);
		void Remove(string key);
	}
}

