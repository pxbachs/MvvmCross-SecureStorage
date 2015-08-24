using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;
using Security;
using Foundation;


namespace FSB.MvvmCross.Plugins.SecureStorage.Touch
{
	public class MvxTouchProtectedData : IMvxProtectedData
	{
		public void Protect(string key, string value)
		{
			Remove (key);

			var code = SecKeyChain.Add(new SecRecord(SecKind.GenericPassword)
				{
					Service = NSBundle.MainBundle.BundleIdentifier,
					Account = key,
					ValueData = NSData.FromString(value, NSStringEncoding.UTF8)
				});
		}

		public string Unprotect(string key)
		{
			var existingRecord = new SecRecord(SecKind.GenericPassword)
			{
				Account = key,
				Service = NSBundle.MainBundle.BundleIdentifier
			};

			// Locate the entry in the keychain, using the label, service and account information.
			// The result code will tell us the outcome of the operation.
			SecStatusCode resultCode;

			string str = null;
			NSData find = SecKeyChain.QueryAsData( existingRecord );
			if( find != null )
			{
				str = find.ToString();

			}
			return str;

		}

		public void Remove(string key)
		{
			var existingRecord = new SecRecord(SecKind.GenericPassword)
			{
				Account = key,
				Service = NSBundle.MainBundle.BundleIdentifier
			};
			var code = SecKeyChain.Remove(existingRecord);
		}
	}

}

