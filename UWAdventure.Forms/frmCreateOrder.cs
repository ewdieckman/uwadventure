using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWAdventure.BLL;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.Forms
{
    public partial class frmCreateOrder : Form
    {

        private readonly StoreViewer _storeViewer;
        private readonly StaffViewer _staffViewer;
        private readonly ProductViewer _productViewer;
        private readonly CustomerViewer _customerViewer;

        private readonly NewOrderCreator _newOrderCreator;

        private readonly Form _calling_form;

        public frmCreateOrder(Form calling_form)
        {
            _storeViewer = new StoreViewer();
            _staffViewer = new StaffViewer();
            _productViewer = new ProductViewer();
            _customerViewer = new CustomerViewer();

            _newOrderCreator = new NewOrderCreator();

            //we pass in the form that opened this form.   Then we know how to get back to it.
            _calling_form = calling_form;
            InitializeComponent();
        }


        #region "Control Events"
        /// <summary>
        /// Event handler for Create Order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CreateOrder();
            }
            else
            {
                MessageBox.Show("Order form is not complete.  Cannot create order.", "Form Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// event handler for Cancel button
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event handler for changing combo box Store
        /// </summary>
        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreViewModel store = (StoreViewModel)cbStore.SelectedItem;

            //clear out the employees - new store of employees coming
            cbStaff.Items.Clear();

            FillInStoreEmployees(store.StoreID);
        }

        /// <summary>
        /// Validates form for all required fields
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool IsValid = true;

            if (cbStore.SelectedItem == null)
                IsValid = false;

            if (cbStaff.SelectedItem == null)
                IsValid = false;

            if (lstBxCustomers.SelectedItem == null)
                IsValid = false;

            if (lstBxProducts.SelectedItem == null)
                IsValid = false;

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity))
                IsValid = false;

            return IsValid;
        }

        /// <summary>
        /// Event handler for the form loading
        /// </summary>
        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            InitialFormPopulate();
        }

        #endregion

        #region "Form Events"
        /// <summary>
        /// Event handler for while the form is closing
        /// </summary>
        private void frmCreateOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            _calling_form.Show();
        }

        #endregion

        #region "Populating form controls"
        /// <summary>
        /// Populates the form with the initial information
        /// </summary>
        private void InitialFormPopulate()
        {
            // load the stores into the combobox
            LoadStores();

            // grab 10 random customers for the customer list box
            LoadCustomers();

            // grab 10 random products for the product list box
            LoadProducts();
        }
        /// <summary>
        /// Loads the stores list into the store combobox
        /// </summary>
        private void LoadStores()
        {
            IList<StoreViewModel> stores = _storeViewer.GetAllStores();

            // populate the combobox
            foreach (StoreViewModel store in stores)
            {
                cbStore.Items.Add(store);
            }

            // select the top option by default
            cbStore.SelectedIndex = 0;

        }

        /// <summary>
        /// Loads in 10 random customers into the customer listbox
        /// </summary>
        private void LoadCustomers()
        {
            IList<CustomerViewModel> customers = _customerViewer.GetRandom10();

            //populate list
            foreach (CustomerViewModel customer in customers)
            {
                lstBxCustomers.Items.Add(customer);
            }
        }

        /// <summary>
        /// Loads in 10 random products into the product listbox
        /// </summary>
        private void LoadProducts()
        {
            IList<ProductViewModel> products = _productViewer.GetRandom10();

            //populate list
            foreach (ProductViewModel product in products)
            {
                lstBxProducts.Items.Add(product);
            }


        }
        /// <summary>
        /// Fills in the employees combobox with employees from the specified store
        /// </summary>
        private void FillInStoreEmployees(int store_id)
        {
            IList<StaffViewModel> staff = _staffViewer.GetAllEmployesByStore(store_id);

            //populate combobox
            foreach (StaffViewModel employee in staff)
            {
                cbStaff.Items.Add(employee);
            }

            //select the top option by default
            cbStaff.SelectedIndex = 0;
        }
        #endregion


        #region "Order creation"
        /// <summary>
        /// creates an order from the form
        /// </summary>
        private void CreateOrder()
        {
            NewOrderDTO newOrderDTO = CreateOrderDTO();
            try
            {
                _newOrderCreator.CreateOrder(newOrderDTO);
                MessageBox.Show("Order created successfully.", "Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating this order: " + ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        /// <summary>
        /// Creates the new order DTO
        /// </summary>
        private NewOrderDTO CreateOrderDTO()
        {
            StaffViewModel selected_staff = (StaffViewModel)cbStaff.SelectedItem;
            StoreViewModel selected_store = (StoreViewModel)cbStore.SelectedItem;
            ProductViewModel selected_product = (ProductViewModel)lstBxProducts.SelectedItem;
            CustomerViewModel selected_customer = (CustomerViewModel)lstBxCustomers.SelectedItem;
            int quantity = Convert.ToInt32(txtQuantity.Text);

            NewOrderDTO newOrderDTO = new NewOrderDTO()
            {
                staff_id = selected_staff.StaffID,
                customer_id = selected_customer.CustomerID,
                order_date = DateTime.Now,
                store_id = selected_store.StoreID
            };

            newOrderDTO.items.Add(CreateOrderItemDTO(selected_product, quantity));

            return newOrderDTO;
        }

        /// <summary>
        /// Creates a new order item DTO
        /// </summary>
        private NewOrderItemDTO CreateOrderItemDTO(ProductViewModel product, int quantity)
        {
            NewOrderItemDTO newOrderItem = new NewOrderItemDTO()
            {
                product_id = product.ProductID,
                quantity = quantity
            };

            return newOrderItem;
        }
        #endregion




    }
}

