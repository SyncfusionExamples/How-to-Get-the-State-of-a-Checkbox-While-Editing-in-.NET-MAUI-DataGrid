using Syncfusion.Maui.Core.Carousel;
using Syncfusion.Maui.DataGrid.DataPager;
using Syncfusion.Maui.DataGrid;
using System.Diagnostics;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.dataGrid.CellRenderers.Remove("CheckBox");
            dataGrid.CellRenderers.Add("CheckBox", new DataGridCheckBoxCellRendererExt());
        }
    }

    public class DataGridCheckBoxCellRendererExt : DataGridCheckBoxCellRenderer
    {
        protected override void OnInitializeDisplayView(DataColumnBase dataColumn, StackLayout? view)
        {
            base.OnInitializeDisplayView(dataColumn, view);

            if (view != null && view.Children[0] is CheckBox checkBox)
            {
                checkBox.PropertyChanging += DataGridCheckBoxCellRendererExt_PropertyChanging;

                checkBox.PropertyChanged += DataGridCheckBoxCellRendererExt_PropertyChanged;
            }
        }

        private async void DataGridCheckBoxCellRendererExt_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;

            if (e.PropertyName == "IsChecked" && checkBox != null && checkBox.IsFocused && !DataGrid!.View!.IsEditingItem)
            {
                var isChecked = (sender as CheckBox)?.IsChecked ?? false;

                // Display an alert dialog
                await Application.Current.MainPage.DisplayAlert(
                    "Checkbox State Changed",
                    $"IsChecked: {isChecked}",
                    "OK"
                );
            }
        }

        private async void DataGridCheckBoxCellRendererExt_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            var checkBox = sender as CheckBox;

            if (e.PropertyName == "IsChecked" && checkBox != null && checkBox.IsFocused && !DataGrid!.View!.IsEditingItem)
            {
                var isChecked = (sender as CheckBox)?.IsChecked ?? false;

                // Display an alert dialog
                await Application.Current.MainPage.DisplayAlert(
                    "Checkbox State Changed",
                    $"IsChecked: {isChecked}",
                    "OK"
                );
            }
        }
    }
}
