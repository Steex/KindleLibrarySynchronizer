using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Interop;

namespace KindleLibrarySynchronizer
{
	public class MyTreeView : TreeView
	{
		private const int TVS_NOSCROLL = 0x2000;
		private const int TVS_NOHSCROLL = 0x8000;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= TVS_NOSCROLL;
				return cp;
			}
		}
	}


	public static class TreeViewExtensions
	{
		private const int SB_HORZ = 0x0;
		private const int SB_VERT = 0x1;

		public enum ScrollBarCommands
		{
			SB_LINEUP = 0,
			SB_LINELEFT = 0,
			SB_LINEDOWN = 1,
			SB_LINERIGHT = 1,
			SB_PAGEUP = 2,
			SB_PAGELEFT = 2,
			SB_PAGEDOWN = 3,
			SB_PAGERIGHT = 3,
			SB_THUMBPOSITION = 4,
			SB_THUMBTRACK = 5,
			SB_TOP = 6,
			SB_LEFT = 6,
			SB_BOTTOM = 7,
			SB_RIGHT = 7,
			SB_ENDSCROLL = 8
		}

		private const uint WM_HSCROLL = 0x114;
		private const uint WM_VSCROLL = 0x115;

		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern IntPtr GetScrollPos(IntPtr hWnd, int nBar);

		[DllImport("user32.dll")]
		public static extern IntPtr SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		public static Point GetScrollPosition(this TreeView treeView)
		{
			return new Point(
				(int)GetScrollPos(treeView.Handle, SB_HORZ),
				(int)GetScrollPos(treeView.Handle, SB_VERT));
		}

		public static void ScrollTo(this TreeView treeView, Point scrollPosition)
		{
			//SetScrollPos(treeView.Handle, SB_HORZ, scrollPosition.X, true);
			//SetScrollPos(treeView.Handle, SB_VERT, scrollPosition.Y, true);
			PostMessage(treeView.Handle, WM_HSCROLL, (IntPtr)(scrollPosition.X << 16 + (int)ScrollBarCommands.SB_THUMBPOSITION), IntPtr.Zero);
			PostMessage(treeView.Handle, WM_VSCROLL, (IntPtr)(scrollPosition.Y << 16 + (int)ScrollBarCommands.SB_THUMBPOSITION), IntPtr.Zero);
		}
	}
}