using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	public partial class SynchroView : UserControl
	{
		private class NodeInfo
		{
			public TreeNode PairNode { get; private set; }
			public BookFolder Folder { get; private set; }
			public BookInfo Book { get; private set; }

			public NodeInfo(TreeNode pairNode, BookFolder folder, BookInfo book)
			{
				PairNode = pairNode;
				Folder = folder;
				Book = book;
			}
		}


		private BookComparer bookComparer;

		public BookComparer BookComparer
		{
			get
			{
				return bookComparer;
			}
			set
			{
				if (bookComparer != value)
				{
					bookComparer = value;
					OnBookComparerChanged(this, EventArgs.Empty);
				}
			}
		}

		public SynchroView()
		{
			InitializeComponent();
		}


		private void FillTrees()
		{
			treeSource.BeginUpdate();
			treeTarget.BeginUpdate();

			// Clear existing items.
			treeSource.Nodes.Clear();
			treeTarget.Nodes.Clear();

			// Fill new items.
			var folderStack = new Stack<BookFolder>();
			var enumeratorStack = new Stack<IEnumerator<BookFolder>>();
			var sourceNodesStack = new Stack<TreeNodeCollection>();
			var targetNodesStack = new Stack<TreeNodeCollection>();

			folderStack.Push(BookComparer.Books);
			enumeratorStack.Push(BookComparer.Books.Folders.GetEnumerator());
			sourceNodesStack.Push(treeSource.Nodes);
			targetNodesStack.Push(treeTarget.Nodes);

			while (folderStack.Count > 0)
			{
				BookFolder folder = folderStack.Peek();
				IEnumerator<BookFolder> enumerator = enumeratorStack.Peek();
				TreeNodeCollection sourceNodes = sourceNodesStack.Peek();
				TreeNodeCollection targetNodes = targetNodesStack.Peek();

				if (enumerator.MoveNext())
				{
					TreeNode sourceNode = sourceNodes.Add(enumerator.Current.Name);
					TreeNode targetNode = targetNodes.Add(enumerator.Current.Name);

					sourceNode.Tag = new NodeInfo(targetNode, enumerator.Current, null);
					targetNode.Tag = new NodeInfo(sourceNode, enumerator.Current, null);

					folderStack.Push(enumerator.Current);
					enumeratorStack.Push(enumerator.Current.Folders.GetEnumerator());
					sourceNodesStack.Push(sourceNode.Nodes);
					targetNodesStack.Push(targetNode.Nodes);
				}
				else
				{
					folderStack.Pop();
					enumeratorStack.Pop();
					sourceNodesStack.Pop();
					targetNodesStack.Pop();

					foreach (BookInfo book in folder.Books)
					{
						TreeNode sourceNode = sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, BookComparer.SourceRoot));
						TreeNode targetNode = targetNodes.Add(Utils.GetRelativePath(book.TargetPath, BookComparer.TargetRoot));

						sourceNode.Tag = new NodeInfo(targetNode, null, book);
						targetNode.Tag = new NodeInfo(sourceNode, null, book);

						switch (book.State)
						{
							case BookState.Actual:
								sourceNode.ForeColor = Color.Black;
								targetNode.ForeColor = Color.Black;
								break;

							case BookState.New:
								sourceNode.ForeColor = Color.Blue;
								targetNode.ForeColor = Color.Blue;
								break;

							case BookState.Changed:
								sourceNode.ForeColor = Color.DarkGreen;
								targetNode.ForeColor = Color.DarkGreen;
								break;

							case BookState.Deleted:
								sourceNode.ForeColor = Color.Silver;
								targetNode.ForeColor = Color.Red;
								break;
						}
					}
				}
			}

			// Refresh the trees.
			treeSource.EndUpdate();
			treeTarget.EndUpdate();
		}

		private void UpdateScrollBar()
		{
			Point pt = treeSource.GetScrollPosition();
		}


		protected virtual void OnBookComparerChanged(object sender, EventArgs args)
		{
			FillTrees();
		}

		private void treeSource_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			UpdateScrollBar();
		}

		private void treeSource_AfterExpand(object sender, TreeViewEventArgs e)
		{
			UpdateScrollBar();
		}

		private void treeSource_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateScrollBar();
		}

		private void treeTarget_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
			}
		}

		private void treeTarget_MouseDown(object sender, MouseEventArgs e)
		{
			treeSource.TopNode = (treeTarget.TopNode.Tag as NodeInfo).PairNode;
			//treeSource.ScrollTo(treeTarget.GetScrollPosition());
			//treeSource.Refresh();
		}
	}
}
