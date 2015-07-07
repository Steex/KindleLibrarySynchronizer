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

		private BookComparer bookComparer;
		private bool synchronizingTrees = false;
		private float treeSplitCoeff = 0.5f;

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
					OnBookComparerChanged(EventArgs.Empty);
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
						TreeNode sourceNode = sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, BookComparer.Library.SourceRoot));
						TreeNode targetNode = targetNodes.Add(Utils.GetRelativePath(book.TargetPath, BookComparer.Library.TargetRoot));

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

		private void SynchronizeScroll(TreeView fromTree, TreeView toTree)
		{
			if (synchronizingTrees)
			{
				return;
			}

			synchronizingTrees = true;

			toTree.TopNode = (fromTree.TopNode.Tag as NodeInfo).PairNode;

			synchronizingTrees = false;
		}

		private void SynchonizeNodeExpanded(TreeNode node)
		{
			if (synchronizingTrees)
			{
				return;
			}

			synchronizingTrees = true;

			if (node.IsExpanded)
			{
				(node.Tag as NodeInfo).PairNode.Expand();
			}
			else
			{
				(node.Tag as NodeInfo).PairNode.Collapse();
			}

			synchronizingTrees = false;
		}

		private void SynchonizeNodeSelected(TreeNode node, TreeView toTree)
		{
			/*if (synchronizingTrees)
			{
				return;
			}

			synchronizingTrees = true;

			if (node.IsSelected)
			{
				toTree.SelectedNode = null;
				(node.Tag as NodeInfo).PairNode.sele();
			}
			else
			{
				(node.Tag as NodeInfo).PairNode.Collapse();
			}

			synchronizingTrees = false;/**/
		}


		protected virtual void OnBookComparerChanged(EventArgs args)
		{
			FillTrees();
		}

		protected override void OnSizeChanged(EventArgs args)
		{
			base.OnSizeChanged(args);

			treeTarget.Left = (int)(ClientSize.Width * treeSplitCoeff);
			treeTarget.Width = ClientSize.Width - treeTarget.Left;
		}

		private void treeSource_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			SynchonizeNodeExpanded(e.Node);
			SynchronizeScroll(treeSource, treeTarget);
		}

		private void treeSource_AfterExpand(object sender, TreeViewEventArgs e)
		{
			SynchonizeNodeExpanded(e.Node);
			SynchronizeScroll(treeSource, treeTarget);
		}

		private void treeSource_AfterSelect(object sender, TreeViewEventArgs e)
		{
			e.Node.EnsureVisible();
			SynchronizeScroll(treeSource, treeTarget);
		}

		private void treeTarget_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			SynchonizeNodeExpanded(e.Node);
			SynchronizeScroll(treeTarget, treeSource);
		}

		private void treeTarget_AfterExpand(object sender, TreeViewEventArgs e)
		{
			SynchonizeNodeExpanded(e.Node);
			SynchronizeScroll(treeTarget, treeSource);
		}

		private void treeTarget_AfterSelect(object sender, TreeViewEventArgs e)
		{
			e.Node.EnsureVisible();
			SynchronizeScroll(treeTarget, treeSource);
		}

	}

	public class NodeInfo
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


}
