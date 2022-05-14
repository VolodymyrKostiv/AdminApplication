using AdminApplication.DTOs;
using AdminApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for CheckEmployees.xaml
    /// </summary>
    public partial class CheckEmployees : UserControl
    {
        public CheckEmployees()
        {
            InitializeComponent();
        }

        private void grdEmployees_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var empl = e.Row.DataContext as EmployeeDTO;
            (DataContext as CheckEmployeesViewModel).UpdateEmployee(empl);
        }
    }
}
