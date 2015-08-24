using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace FSB.MvvmCross.Plugins.SecureStorage.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IMvxProtectedData>(new MvxAndroidProtectedData());
		}
	}
}

