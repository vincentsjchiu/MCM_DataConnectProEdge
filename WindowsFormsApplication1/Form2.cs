using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MCMDB;
namespace WindowsFormsApplication1
{
    public partial class Form2 : MetroForm
    {
        public DateTime startD, endD, startT, endT;

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            startD = dateTimePickerFromDate.Value.Date + dateTimePickerFromTime.Value.TimeOfDay;
            endD = dateTimePickerEndDate.Value.Date + dateTimePickerEndTime.Value.TimeOfDay;            
        }

        public string tablename;                 
        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePickerFromDate.Value = startD;
            dateTimePickerFromTime.Value = startD;
            dateTimePickerEndDate.Value = endD;
            dateTimePickerEndTime.Value = endD;

        }       

        public Form2()
        {
            InitializeComponent();
            dateTimePickerFromDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerFromDate.CustomFormat = "yyyy-MM-dd";

            dateTimePickerFromTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerFromTime.CustomFormat = "HH:mm:ss";
            dateTimePickerFromTime.ShowUpDown = true;

            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd";

            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "HH:mm:ss";
            dateTimePickerEndTime.ShowUpDown = true;

        }
    }
}
