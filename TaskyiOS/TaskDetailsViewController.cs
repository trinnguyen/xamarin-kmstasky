using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tasky.Core.BL;
using Tasky.Core.BL.Managers;

namespace TaskyiOS
{
	public partial class TaskDetailsViewController : UIViewController
	{
		protected Task _task;
		public TaskDetailsViewController () : base ("TaskDetailsViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.txtName.ReturnKeyType = UIReturnKeyType.Next;
			this.txtName.ShouldReturn += (t) => { this.txtNote.BecomeFirstResponder(); return true; };

			this.txtNote.ReturnKeyType = UIReturnKeyType.Done;
			this.txtNote.ShouldReturn += (t) => { this.txtNote.ResignFirstResponder(); return true; };
		}

		#region handler
		partial void HandleBtnCancelTouch (MonoTouch.Foundation.NSObject sender)
		{
			if(this._task.ID != 0)
			{
				TaskManager.DeleteTask(this._task.ID);
			}

			this.NavigationController.PopViewControllerAnimated(true);
		}

		partial void HandleBtnSaveTouch (MonoTouch.Foundation.NSObject sender)	
		{
			this._task.Name = this.txtName.Text;
			this._task.Notes = this.txtNote.Text;
			TaskManager.SaveTask(this._task);
			this.NavigationController.PopViewControllerAnimated(true);
		}
		#endregion

		public void UpdateTask (Tasky.Core.BL.Task task)
		{
			_task = task;
			this.btnCancel.SetTitle((this._task.ID == 0 ? "Cancel" : "Delete"), UIControlState.Normal);

			this.txtName.Text = this._task.Name;
			this.txtNote.Text = this._task.Notes;

			this.View.EndEditing (true);
		}
	}
}

