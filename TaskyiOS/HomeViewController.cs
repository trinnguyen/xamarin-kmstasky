using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tasky.Core.BL.Managers;
using Tasky.Core.BL;

namespace TaskyiOS
{
	public partial class HomeViewController : UIViewController
	{
		private UIBarButtonItem _btnAdd;
		private UITableView _tableView;
		private TaskTableSource _tableSource;

		private TaskDetailsViewController _taskDetailViewController;

		public HomeViewController () : base ("HomeViewController", null)
		{
			Title = "Tasks";
			_taskDetailViewController = new TaskDetailsViewController ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// reload/refresh
			this.PopulateTable();			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			_tableSource = new TaskTableSource ();
			_tableSource.TaskClicked += HandleTaskItemClicked;
			_tableSource.TaskDeleted += HandleTaskItemDeleted;

			_tableView = new UITableView (this.View.Bounds);
			_tableView.Source = _tableSource;
			this.View.AddSubview (_tableView);

			_btnAdd = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			_btnAdd.Clicked += HandleAddTaskClick;
			NavigationItem.RightBarButtonItem = _btnAdd;
		}

		#region handler
		void HandleTaskItemClicked (object sender, TaskClickedEventArgs e)
		{
			this.NavigationController.PushViewController(this._taskDetailViewController, true);
			_taskDetailViewController.UpdateTask (e.Task);
		}
		void HandleTaskItemDeleted (object sender, TaskClickedEventArgs e)
		{
			TaskManager.DeleteTask(e.Task.ID);
			this.PopulateTable();
		} 
		void HandleAddTaskClick(object sender, EventArgs e)
		{
			NavigationController.PushViewController (_taskDetailViewController, true);
			_taskDetailViewController.UpdateTask (new Task ());
		}
		#endregion
		void PopulateTable ()
		{
			_tableSource.Tasks = TaskManager.GetTasks ();
			_tableView.ReloadData ();
		}
	}
}

