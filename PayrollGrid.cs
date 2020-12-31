﻿using Android.App;
using Android.Views;
using Android.Widget;
using PayrollParrots.Model;

namespace PayrollParrots
{
    public class GridPayroll : BaseAdapter
    {
        private readonly Activity context;
        private readonly Payroll[] listitem;
        public override int Count
        {
            get
            {
                return listitem.Length;
            }
        }
        public GridPayroll(Activity context, Payroll[] listitem)
        {
            this.context = context;
            this.listitem = listitem;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listitem.Length;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.payroll_grid, parent, false);
            TextView nameOfEmployee = (TextView)view.FindViewById(Resource.Id.nameOfEmployee);
            TextView monthOfPayroll = (TextView)view.FindViewById(Resource.Id.monthOfPayroll);
            //items to show on list front
            monthOfPayroll.Text = "Month: " + listitem[position].Month.ToString() + " ";
            nameOfEmployee.Text = "Name: " + listitem[position].Name.ToString();
            return view;
        }
    }
}
