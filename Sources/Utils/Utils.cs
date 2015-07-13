using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace KindleLibrarySynchronizer
{
	public static class Utils
	{
		public static readonly char[] DirectorySeparators = { '/', '\\' };
		public static readonly char[] ListSeparators = { ',', ' ', ';' };


		public static void ShowErrorMessage(IWin32Window owner, Exception exception)
		{
			string message = "An error has occurred with the message:\n\n" + exception;
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowErrorMessage(IWin32Window owner, string message)
		{
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowWarningMessage(IWin32Window owner, string message)
		{
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public static DialogResult ShowQuestion(IWin32Window owner, string message, MessageBoxButtons buttons)
		{
			return MessageBox.Show(owner, message, Application.ProductName, buttons, MessageBoxIcon.Question);
		}


		public static bool ParseBool(string str, bool defaultValue)
		{
			return str == "1";
		}

		public static string BoolToString(bool value)
		{
			return value ? "1" : "0";
		}


		public static T ReadRegistryValue<T>(RegistryKey key, string name, T defaultValue)
		{
			try
			{
				string strValue = (string)key.GetValue(name, InvariantConverter.ToString(defaultValue));
				return InvariantConverter.FromString<T>(strValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static IEnumerable<string> ReadRegistryList(RegistryKey key, string baseName)
		{
			return ReadRegistryList<string>(key, baseName);
		}

		public static IEnumerable<T> ReadRegistryList<T>(RegistryKey key, string baseName)
		{
			for (int index = 1; ; ++index)
			{
				object value = key.GetValue(baseName + index.ToString());
				if (value != null)
				{
					yield return InvariantConverter.FromString<T>(value.ToString());
				}
				else
				{
					break;
				}
			}
		}

		public static void WriteRegistryValue<T>(RegistryKey key, string name, T value)
		{
			if (value != null)
			{
				key.SetValue(name, InvariantConverter.ToString(value));
			}
			else
			{
				key.SetValue(name, "");
			}
		}

		public static void WriteRegistryList<T>(RegistryKey key, string baseName, IEnumerable<T> list)
		{
			if (list != null)
			{
				int index = 1;
				foreach (T item in list)
				{
					Utils.WriteRegistryValue(key, baseName + index.ToString(), InvariantConverter.ToString(item));
					++index;
				}
			}
		}


		public static float EnsureRange(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			else if (value > max)
			{
				return max;
			}
			else
			{
				return value;
			}
		}

		public static int EnsureRange(int value, int min, int max)
		{
			if (value < min)
			{
				return min;
			}
			else if (value > max)
			{
				return max;
			}
			else
			{
				return value;
			}
		}

		
		public static string GetRelativePath(string path, string root)
		{
			if (root == null || root.Length == 0)
			{
				return path;
			}

			path = path.Replace('/', '\\');
			root = root.Replace('/', '\\');

			if (!root.EndsWith("\\"))
			{
				root += '\\';
			}

			if (path.StartsWith(root, StringComparison.InvariantCultureIgnoreCase))
			{
				return path.Substring(root.Length);
			}
			else
			{
				return path;
			}
		}

		public static string RemoveExtension(string path)
		{
			if (path == null || path.Length == 0)
			{
				return path;
			}

			for (int i = path.Length - 1; i >= 0; --i)
			{
				char symbol = path[i];
				if (symbol == '\\' || symbol == '/')
				{
					return path;
				}
				else if (symbol == '.')
				{
					return path.Substring(0, i);
				}
			}

			return path;
		}

		public static void MoveFile(string sourcePath, string targetPath)
		{
			if (File.Exists(targetPath))
			{
				File.Copy(sourcePath, targetPath, true);
				File.Delete(sourcePath);
			}
			else
			{
				File.Move(sourcePath, targetPath);
			}
		}


		public static string AbbreviateString(string value)
		{
			if (value == null)
			{
				return null;
			}

			// Normalize the string: remove leading whitespace, replace all whitespace symbols with a single space.
			string normalizedValue = "";

			bool separatorIsAllowed = false;
			foreach (char chr in value)
			{
				bool isSeparator = Char.IsSeparator(chr);

				if (!isSeparator)
				{
					normalizedValue += chr;
					separatorIsAllowed = true;	
				}
				else if (separatorIsAllowed)
				{
					normalizedValue += ' ';
					separatorIsAllowed = false;
				}
			}

			// Some custom logic: remove English articles from the start of the string.
			if (normalizedValue.StartsWith("a ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(2);
			}
			else if (normalizedValue.StartsWith("an ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(3);
			}
			else if (normalizedValue.StartsWith("the ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(4);
			}

			// Make an abbreviation of the cleared string by including only essential symbols.
			// A symbol is consider essential if
			// - it is a digit
			// - it is an uppercase letter
			// - it is a lowercase letter in the beginning of word
			string abbreviation = "";

			bool waitForNewWord = true;
			foreach (char chr in normalizedValue)
			{
				bool acceptAllways = Char.IsUpper(chr) || Char.IsDigit(chr);
				bool acceptAtWordStart = Char.IsLetter(chr);

				if (acceptAllways ||
					acceptAtWordStart && waitForNewWord)
				{
					abbreviation += Char.ToUpper(chr);
					waitForNewWord = false;
				}

				waitForNewWord = !acceptAllways && !acceptAtWordStart;
			}

			return abbreviation;
		}
	}
}
