using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;

namespace WpfApp_Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public readonly IListPropertyResponseObjRepo listPropertyResponseObjRepo;
        public readonly IItemPropertyResponseObjRepo itemPropertyResponseObjRepo;


        public MainWindow(IListPropertyResponseObjRepo listPropertyResponseObjRepo, IItemPropertyResponseObjRepo itemPropertyResponseObjRepo)
        {
            this.listPropertyResponseObjRepo = listPropertyResponseObjRepo;
            this.itemPropertyResponseObjRepo = itemPropertyResponseObjRepo;
            InitializeComponent();
        }

        public void clear_itemInfo_txtboxes()
        {
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemDesc.Text = "";
        }

        public async void PopulateListview()
        {
            //listPropertyResponseObjRepo.GetLists();
            var data = await listPropertyResponseObjRepo.GetLists();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ListID");
            dataTable.Columns.Add("ListName");
            dataTable.Columns.Add("ListDesc");

            foreach (var list in data.ToList())
            {
                var row = dataTable.NewRow();

                row["ListID"] = list.ListID;
                row["ListName"] = list.ListName;
                row["ListDesc"] = list.ListDesc;

                dataTable.Rows.Add(row);
            }
            await Dispatcher.BeginInvoke(new ThreadStart(() => lvwList.ItemsSource = dataTable.AsDataView()));
        }

        public void FetchListProperty(ListPropertyResponseObj ListPropertyResponseObj)
        {
            ListPropertyResponseObj.ListName = txtItemName.Text;
            ListPropertyResponseObj.ListDesc = txtItemDesc.Text;   

            if (txtItemID.Text.Trim() == string.Empty)
            {
                ListPropertyResponseObj.ListID = 0;
            }
            else
            {
                string id = txtItemID.Text.ToString();
                ListPropertyResponseObj.ListID = Int16.Parse(id);
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateListview();
        }

        private void lvwList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwList.SelectedItem is not DataRowView row) //clear textboxes if no selecteditem
            {
                clear_itemInfo_txtboxes();
            }
            else
            {
                string iid = row.Row.ItemArray[0].ToString();
                ListPropertyResponseObj listPropertyResponseObj = new ListPropertyResponseObj
                {
                    ListID = Int16.Parse(iid),
                    ListName = row.Row.ItemArray[1].ToString(),
                    ListDesc = row.Row.ItemArray[2].ToString()
                };

                txtItemID.Text = listPropertyResponseObj.ListID.ToString();
                txtItemName.Text = listPropertyResponseObj.ListName.ToString();
                txtItemDesc.Text = listPropertyResponseObj.ListDesc.ToString();
                //PopulateItemGrid(listProperty.ID);
            }

        }
        private void lvwList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grpItem.Visibility = Visibility.Visible;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            clear_itemInfo_txtboxes();
            if (grpItem.Visibility != Visibility.Visible)
            {
                grpItem.Visibility = Visibility.Visible;
            }
            else
            {
                //Do Nothing
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (grpItem.Visibility != Visibility.Visible)
            {
                grpItem.Visibility = Visibility.Visible;

            }
            else
            {
                //Do Nothing
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clear_itemInfo_txtboxes();
            grpItem.Visibility = Visibility.Collapsed;
        }
        
        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("No selected item.");
                return;
            }
            string iid = txtItemID.Text;

            //Populate item form
            ItemForm itemForm = new ItemForm(itemPropertyResponseObjRepo);
            itemForm.txtListID.Text = iid.ToString();
            itemForm.ShowDialog();
        }


        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ListPropertyResponseObj listPropertyResponseObj = new ListPropertyResponseObj();

            FetchListProperty(listPropertyResponseObj);

            string response = "";

            if (listPropertyResponseObj.ListID == 0)
            {
                //Add new List
                response = await listPropertyResponseObjRepo.InsertList(listPropertyResponseObj);

                if (response == "OK")
                {
                    MessageBox.Show("New list added");
                    PopulateListview();
                }
                else
                {
                    MessageBox.Show(response);
                    return;
                }
            }
            else
            {
                //Update current record
                response = await listPropertyResponseObjRepo.UpdateList(listPropertyResponseObj);

                if (response == "OK")
                {
                    MessageBox.Show("Updated list");
                    PopulateListview();
                }
                else
                {
                   MessageBox.Show(response);
                   return;
                }
            }
        }

       
        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvwList.SelectedItem is not DataRowView row)
            {
                MessageBox.Show("No selected item.");
                return;
            }
            //Remove item attachment from list
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            string lid = row.Row.ItemArray[0].ToString();
            int listID = Int16.Parse(lid);
            
            string response;

            if (result == MessageBoxResult.Yes)
            {

                response = await listPropertyResponseObjRepo.Deletelist(listID);
                //Delete item detail also

                if (response == "OK")
                {
                    MessageBox.Show($"Deleted List. {response}");
                    PopulateListview();
                }
                else
                {
                    MessageBox.Show($"Cannot delete list a this time due to {response}.");
                    return;
                }
            }
            else
            {
                //Do Nothing
                return;
            }
        }

    }
}
