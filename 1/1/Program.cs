using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //добавление
            /* using (HotelEntities db = new HotelEntities())
             {
                 Customer c = new Customer();
                 c.Age = 100;
                 c.Email ="someemail#mail.ru";
                 c.FirstName = "Peter";
                 c.LastName = "Pen";
                 c.PassportID = 123456;
                 c.Phone = "7-999-999-99-99";
                 db.Customers.Add(c);
                 db.SaveChanges();
             }
               using (HotelEntities db = new HotelEntities())
             {
                 Customer c = new Customer();
                 c.Age = 200;
                 c.Email ="someemail2#mail.ru";
                 c.FirstName = "Dan";
                 c.LastName = "Pen";
                 c.PassportID = 123457;
                 c.Phone = "7-889-999-99-99";
                 db.Customers.Add(c);
                 db.SaveChanges();
             }
             using (HotelEntities db = new HotelEntities())
             {
                 Booking c1 = new Booking();
                 c1.ArrivalDate = new DateTime(2001, 01, 20);
                 c1.ArrivalTime = new TimeSpan(12, 30, 0);
                 c1.DepartureDate = new DateTime(2001, 01, 20);
                 c1.DepartureTime = new TimeSpan(12, 30, 0);
                 c1.CustomersId = db.Customers.Where(customer => customer.FirstName == "Dan").FirstOrDefault().Id;
                 c1.RoomId = db.Rooms.FirstOrDefault().Id;
                 db.Bookings.Add(c1);
                 db.SaveChanges();
             }*/

            //изменение
            using (HotelEntities db = new HotelEntities())
            {
                Customer p1 = db.Customers.Where((customer) => customer.FirstName == "Peter").FirstOrDefault();
                p1.Age = 30000;
                db.SaveChanges();
            }
            //удаление
            using (HotelEntities db = new HotelEntities())
            {
                Customer p1 = db.Customers.Where((customer) => customer.FirstName == "Dan").FirstOrDefault();
                if (p1!=null)
                {
                    db.Customers.Remove(p1);
                    db.SaveChanges();
                }
                
            }
            //Вывод данных из соединения 2-х таблиц (Booking Customers)
            using (HotelEntities db = new HotelEntities())
            {
                var bookings = db.Bookings.Join(db.Customers, 
                    booking => booking.CustomersId,
                    customer => customer.Id, 
                    (booking, customer) => new
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.Phone,
                        ArrivalDate=booking.ArrivalDate,
                        DepartureDate=booking.DepartureDate,
                        Age=customer.Age,
                    });
                foreach (var b in bookings)
                    Console.WriteLine(string.Format("({0} {1} {5} years) Phone: {2} ArrivalDate: {3} DepatureDate: {4}\n",
                           b.FirstName,b.LastName,b.Phone,b.ArrivalDate,b.DepartureDate, b.Age));
            }
            Console.ReadKey();
        }

    }
}
