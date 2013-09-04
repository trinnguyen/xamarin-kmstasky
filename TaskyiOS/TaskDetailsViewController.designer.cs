// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TaskyiOS
{
	[Register ("TaskDetailsViewController")]
	partial class TaskDetailsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSave { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtNote { get; set; }

		[Action ("HandleBtnCancelTouch:")]
		partial void HandleBtnCancelTouch (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleBtnSaveTouch:")]
		partial void HandleBtnSaveTouch (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtNote != null) {
				txtNote.Dispose ();
				txtNote = null;
			}

			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}
		}
	}
}
