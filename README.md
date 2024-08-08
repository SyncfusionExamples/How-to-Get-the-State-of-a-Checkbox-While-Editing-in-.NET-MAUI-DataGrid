# How to get the state of a Checkbox while editing in .NET MAUI DataGrid
In this article, we will show you how to get the state of a Checkbox while editing in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml
```
<syncfusion:SfDataGrid x:Name="dataGrid" 
                       AutoGenerateColumnsMode="None"
                       ColumnWidthMode="Auto"
                       GridLinesVisibility="Both"
                       HeaderGridLinesVisibility="Both"
                       ItemsSource="{Binding Employees}">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:DataGridCheckBoxColumn MappingName="EmployeeStatus"
                                           HeaderText="Employee Status" />
        <syncfusion:DataGridTextColumn MappingName="EmployeeID"
                                       HeaderText="Employee ID" />
        <syncfusion:DataGridTextColumn MappingName="Name"
                                       HeaderText="Employee Name" />
        <syncfusion:DataGridTextColumn MappingName="Title"
                                       HeaderText="Designation" />
    </syncfusion:SfDataGrid.Columns>

</syncfusion:SfDataGrid>
```

## C#
The below code illustrates how to get the state of a Checkbox while editing in DataGrid.
```
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
```
 ![CheckBoxState.gif](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI3OTg4Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.w-BY9Qlpv-Z8Ov4HzAR_EzGUty6WSiyrEeBqsFSL1Ww)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-Get-the-State-of-a-Checkbox-While-Editing-in-.NET-MAUI-DataGrid)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to get the state of a Checkbox while editing in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!