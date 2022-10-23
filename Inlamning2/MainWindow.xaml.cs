using Inlamning1;
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

namespace Inlamning2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddressBook addressBook = new AddressBook();
        int lastShownContactNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
            RefreshContactList();
            DeleteContactButton.Visibility = Visibility.Hidden;

        }

        private void New_contact_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Address.Text) || string.IsNullOrWhiteSpace(Email.Text)) 
            {
                MessageBox.Show("All fields must have a value", "Error");
                return;
            } 
            addressBook.AddContact(Name.Text, Address.Text, Email.Text);
            RefreshContactList();
            Name.Clear();
            Address.Clear();
            Email.Clear();

        }
        
        private void RefreshContactList()
        {
            ContactList.Items.Clear();
            addressBook.DisplayAllContacts(ContactList);
        }

        private void Show_contact_details(object sender, RoutedEventArgs e)
        {
            if (ContactList.SelectedItem == null)
            {
                MessageBox.Show("Select a contact", "Error");
                return;
            }
            DeleteContactButton.Visibility = Visibility.Visible;
            Contacts selectedContact = ContactList.SelectedItem as Contacts;
            ContactDetailsBlock.Text = selectedContact.Name + "\n" + selectedContact.Address + "\n" + selectedContact.Email;
            lastShownContactNumber = selectedContact.Number;
        }

        private void Delete_contact(object sender, RoutedEventArgs e)
        {
            addressBook.DeleteContact(lastShownContactNumber);
            RefreshContactList();
            ContactDetailsBlock.Text = "";
            DeleteContactButton.Visibility = Visibility.Hidden;
        }
    }
}
