using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Contact selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; }
        private RelayCommand addCommand;
        private RelayCommand removeCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Contact contact = new Contact();
                        Contacts.Insert(0, contact);
                        selectedContact = contact;
                    }));
            }

        }
    
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Contact phone = obj as Contact;
                        if(phone!=null)
                        {
                            Contacts.Remove(phone);
                        }
                    },
                    (obj) => Contacts.Count>0
                    ));
            }
        }
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }
        public ApplicationViewModel()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact {Name="Альберт", Surname="Макаров", Phone="89111234567"},
                new Contact {Name="Мария", Surname="Кузнецова", Phone="89112234568"},
                new Contact {Name="Татьяна", Surname="Смирнова", Phone="89113234569"},
                new Contact {Name="Александр", Surname="Тихонов", Phone="89114234560"},
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }

}
