﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Globals.Load();
			Application.Run(new MainForm());
			Globals.Save();
		}
	}
}
