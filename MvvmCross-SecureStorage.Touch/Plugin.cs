using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace FSB.MvvmCross.Plugins.SecureStorage.Touch
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IMvxProtectedData>(new MvxTouchProtectedData());
		}
	}
}

