using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;


namespace Prodotti_grafica
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       
        public MainWindow()
        {
        InitializeComponent();
            DataContext = this; 
             Statistics = new ObservableCollection<Products>();
        }

        public event PropertyChangedEventHandler PropertyChanged;



       // protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public const string FLD_Statistics = "Statistics";
      
        private ObservableCollection<Products> mStatistics;

        public ObservableCollection<Products> Statistics
        {
            get
            {
                return mStatistics;
            }
            private set
            {
                mStatistics = value;
              //  OnPropertyChanged(FLD_Statistics);
             
            }
        }



        public async void DGview()
        {
            Statistics.Clear();
           // BindingList<Products> lstData = new BindingList<Products>();
            var con = new Connection();// dalla classe Connessione creo l'oggetto
            var connessioneDB = con.ConnessioneDB(); // creo la connessione 
            await connessioneDB.OpenAsync();

            var l1 = new SqlCommand("SELECT * FROM TProducts inner join TDescription on TProducts.id = TDescription.IdProducts", connessioneDB);

            SqlDataReader r1 = await l1.ExecuteReaderAsync(); //Command.ExecuteReader();

            while (r1.Read())
            {
                Statistics.Add(new Products(System.Convert.ToInt32(r1["id"]), System.Convert.ToInt32(r1[1]), System.Convert.ToInt32(r1[2]), r1[5].ToString()));
            }
            DG1.DataContext = Statistics;
        }

        public void DGview2()
        {
            List<Products> list = new List<Products>();

            using (var f = new Conn())
            {
                //var d = f.TProducts.First(o=>o.Description.id == 2); Include("Prodotti.TProducts.id")
                var d = f.TProducts.Include(p => p.Description).ToList();//.FirstOrDefault(o => o.id == 2);//.Where(o => o.id == 2).Cast<Products>();//.First(o => o.Description.id == 2);

               
                //list.Add(new Products() {id= d.id, Price=d.Price, Quantity=d.Quantity, 
                //   Description= new Description() {Name=d.Description.Name } });
                //}
                DG1.DataContext = d;// datagrid

            }
        }
        public void Up()
        {
            using (var f = new Conn())
            {
                var cust = f.TProducts.Include(p => p.Description).ToList();

                // cust.Add();
               up up = new up();
                up.Show();
                
                f.SaveChanges();
            }
        }

        

        public void Up2()
        {
            using (var f = new Conn())
            {
                var cust = f.TProducts.First(o => o.id == 2);
                cust.Description.Name = "MODIFICATO";
                f.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DGview();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Up();
        }

       


    }
}
