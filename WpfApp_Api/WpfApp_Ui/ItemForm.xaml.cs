using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Services.Commands.ItemCommands;
using WpfAppUi_Services.Queries.ItemQueries;

namespace WpfApp_Ui
{
    /// <summary>
    /// Interaction logic for ItemForm.xaml
    /// </summary>
    public partial class ItemForm : Window
    {


        #region Repository Procedures
        public async Task<IEnumerable<ItemPropertyResponseObj>> GetItem(int ListId)
        {
            var query = new GetItemQuery(ListId);
            var data = await _mediator.Send(query);
            return data;
        }

        public async Task<string> InsertItem(ItemPropertyResponseObj itemPropertyResponseObj)
        {
            var query = new InsertItemCommand(itemPropertyResponseObj);
            var data = await _mediator.Send(query);
            return data.ToString(); ;
        }

        public async Task<string> UpdateItem(ItemPropertyResponseObj itemPropertyResponseObj)
        {
            var query = new UpdateItemCommand(itemPropertyResponseObj);
            var data = await _mediator.Send(query);
            return data;
        }

        public async Task<string> DeleteItemByItemId(int itemId)
        {
            var query = new DeleteItemByItemIdCommand(itemId);
            var data = await _mediator.Send(query);
            return data.ToString(); ;
        }

        public async Task<string> DeleteItemByListId(int listId)
        {
            var query = new DeleteItemByListIdCommand(listId);
            var data = await _mediator.Send(query);
            return data.ToString(); ;
        }

        #endregion


        #region Other Procedures
        public void ClearItemInfoTextboxes()
        {
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemDesc.Text = "";
        }

        public string ConvertStatusToString(int itemStatus)
        {
            string result = "Unavailable";
            if (itemStatus == 1)
            {
                result = "Available";
            }

            return result;
        }
        public int ConvertStatusToInt(string itemStatus)
        {
            int result = 0;
            if (itemStatus == "Available")
            {
                result = 1;
            }
            return result;
        }

        public async void PopulateItemView()
        {
            int listID = Convert.ToInt32(txtListID.Text);

            var data = await GetItem(listID);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ItemID");
            dataTable.Columns.Add("ItemName");
            dataTable.Columns.Add("ItemDesc");
            dataTable.Columns.Add("ItemStatus");

            foreach (var list in data.ToList())
            {
                var row = dataTable.NewRow();

                row["ItemID"] = list.ItemID;
                row["ItemName"] = list.ItemName;
                row["ItemDesc"] = list.ItemDesc;
                row["ItemStatus"] = ConvertStatusToString(list.ItemStatus);

                dataTable.Rows.Add(row);
            }
            await Dispatcher.BeginInvoke(new ThreadStart(() => lvwItems.ItemsSource = dataTable.AsDataView()));
        }

        public void FetchItemProperty(ItemPropertyResponseObj ItemPropertyResponseObj)
        {
            string lid = txtListID.Text;
            int itemStatus = ConvertStatusToInt(cboStatus.Text);
            ItemPropertyResponseObj.ListID = Int16.Parse(lid);
            ItemPropertyResponseObj.ItemName = txtItemName.Text;
            ItemPropertyResponseObj.ItemDesc = txtItemDesc.Text;
            ItemPropertyResponseObj.ItemStatus = itemStatus;

            if (txtItemID.Text.Trim() == string.Empty)
            {
                ItemPropertyResponseObj.ItemID = 0;
            }
            else
            {
                string id = txtItemID.Text.ToString();
                ItemPropertyResponseObj.ItemID = Int16.Parse(id);
            }
        }
        #endregion

        private readonly IMediator _mediator;
        public ItemForm(IMediator mediator)
        {
            this._mediator = mediator;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateItemView();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            ClearItemInfoTextboxes();
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

        private void lvwItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwItems.SelectedItem is not DataRowView row)
            {
                ClearItemInfoTextboxes();
            }
            else
            {
                string iid = row.Row.ItemArray[0].ToString();
                ItemPropertyResponseObj ItemPropertyResponseObj = new ItemPropertyResponseObj
                {
                    ItemID = Int16.Parse(iid),
                    ItemName = row.Row.ItemArray[1].ToString(),
                    ItemDesc = row.Row.ItemArray[2].ToString(),
                };

                txtItemID.Text = ItemPropertyResponseObj.ItemID.ToString();
                txtItemName.Text = ItemPropertyResponseObj.ItemName.ToString();
                txtItemDesc.Text = ItemPropertyResponseObj.ItemDesc.ToString();
                cboStatus.Text = row.Row.ItemArray[3].ToString();
            }
        }

        private void lvwItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grpItem.Visibility = Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearItemInfoTextboxes();
            grpItem.Visibility = Visibility.Collapsed;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemName.Text == "" || txtItemDesc.Text == "" || cboStatus.Text == "")
            {
                MessageBox.Show("Please enter item Name, Description and Status.");
                return;
            }


            ItemPropertyResponseObj itemPropertyResponseObj = new ItemPropertyResponseObj();
            FetchItemProperty(itemPropertyResponseObj);

            string response = "";
            if (itemPropertyResponseObj.ItemID == 0)
            {

                //Insert new item
                response = await InsertItem(itemPropertyResponseObj);
                if (response == "OK")
                {
                    MessageBox.Show("New item added");
                    PopulateItemView();
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
                response = await UpdateItem(itemPropertyResponseObj);
                if (response == "OK")
                {
                    MessageBox.Show("Udpated item.");
                    PopulateItemView();
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
            if (lvwItems.SelectedItem is not DataRowView row)
            {
                MessageBox.Show("No selected item.");
                return;
            }
            //Remove item attachment from list
            MessageBoxResult result = MessageBox.Show("Do you want to remove this item?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            string iid = row.Row.ItemArray[0].ToString();
            int ItemID = Int16.Parse(iid);

            string response;

            if (result == MessageBoxResult.Yes)
            {

                response = await DeleteItemByItemId(ItemID);
                //Delete item detail also

                if (response == "OK")
                {
                    MessageBox.Show($"Deleted Item. {response}");
                    PopulateItemView();
                }
                else
                {
                    MessageBox.Show($"Cannot delete item a this time due to {response}.");
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
