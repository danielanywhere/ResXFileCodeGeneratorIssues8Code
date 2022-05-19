//	Program.cs
//	Copyright(c) 2022. Ascendant Design and Training, LLC
//	This file is licensed under the MIT License.
//	Please see the LICENSE file in this project.
//
//	*** WARNING ***
//	This file is for diagnostic purposes only and has been configured to
//	cause a specific error. Much of its normal functionality is missing and
//	it is not suitable for production.
//	***

namespace WebView2CoreTest
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}
	}
}