using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Tasky.Core.BL.Managers;
using Tasky.Core.DAL;
using Tasky.Core.BL;

namespace TaskyAndroid
{
    [Activity(Label = "TaskyAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeActivity : Activity
    {
        protected TaskListAdapter _taskList;
        protected IList<Task> _tasks;
        protected Button _addTaskButton;
        protected ListView _taskListView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnAddTask);

            button.Click += new EventHandler(HandleAddTaskClick);

            _taskListView = FindViewById<ListView>(Resource.Id.lstTasks);
            _taskListView.ItemClick += new EventHandler<AdapterView.ItemClickEventArgs>(HandleTaskItemClick);
        }

        void HandleTaskItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var taskDetails = new Intent(this, typeof(TaskDetailsActivity));
            taskDetails.PutExtra("TaskID", this._tasks[e.Position].ID);
            this.StartActivity(taskDetails);
        }

        void HandleAddTaskClick(object sender, EventArgs e)
        {
            this.StartActivity(typeof(TaskDetailsActivity));
        }

        protected override void OnResume()
        {
            base.OnResume();

            this._tasks = TaskManager.GetTasks();

            // create our adapter
            this._taskList = new TaskListAdapter(this, this._tasks);

            //Hook up our adapter to our ListView
            this._taskListView.Adapter = this._taskList;
        }
    }
}

