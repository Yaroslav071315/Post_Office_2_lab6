using Lab_2.Data;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using Post_Office_2.Data;
using System.Diagnostics;
using System.Globalization;

namespace Post_Office_2
{
    public partial class Form1 : MaterialForm
    {
        private readonly AppDbContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                // Отримати дані з полів введення
                int weight = int.Parse(textBox1.Text);
                DateTime dateSend = DateTime.Parse(textBox2.Text);
                DateTime dateCome = DateTime.Parse(textBox3.Text);
                decimal price = decimal.Parse(textBox4.Text);

                // Створити новий об'єкт Parcel з введеними даними
                var parcel = new Lab_2.Data.Parcel(weight, dateSend, dateCome, price)
                {
                    Weight = weight,
                    DateSend = dateSend,
                    DateCome = dateCome,
                    Price = price,
                    //CreatedAt = DateTime.Now // При необхідності додати дату створення
                };

                // Додати посилку до контексту бази даних
                _context.Parcels.Add(parcel);

                // Зберегти зміни у базі даних
                _context.SaveChanges();

                MessageBox.Show("Parcel added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистити поля введення після додавання посилки
                textBox1.Clear();
                textBox1.Clear();
                textBox1.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Error adding parcel. Please check input data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Get data from field Отримуємо дані з полів форми
            int weight = int.Parse(textBox1.Text);
            DateTime dateSend = DateTime.Parse(textBox2.Text);
            DateTime dateCome = DateTime.Parse(textBox3.Text);
            decimal price = decimal.Parse(textBox4.Text);

            //Form string for writing in file Формуємо рядок для запису в файл
            string data = $"{weight}, {dateSend}, {dateCome}, {price}";

            //Write data inside file with succor static-class FileHelper Записуємо дані у файл за допомогою класу-допоміжника
            FileHelper.WriteToFile("E:\\Student\\Post_Office_2\\INFO.TXT", data);

            //Clear text Fields Очищаємо текстові поля
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            MessageBox.Show("Horay, parcel sended!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // read data from file
            List<string> parcelInfo = new List<string>();

            using (StreamReader reader = new StreamReader("E:\\Student\\Post_Office_2\\INFO.TXT"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    parcelInfo.Add(line);
                }
            }

            // Sorted data by date come
            List<string> sortedStudentInfo = parcelInfo.OrderBy(s =>
            {
                string[] parts = s.Split(',');
                if (parts.Length >= 3 && parts.Length < 4)
                {
                    return DateTime.ParseExact(parts[2].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return DateTime.MaxValue;
                }
            }).ToList();

            string sortedInfo = string.Join(Environment.NewLine, sortedStudentInfo);

            MessageBox.Show("Parcels list:\n\n" + sortedInfo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Query the Parcels DbSet and sort by DateSend
                var sortedParcels = _context.Parcels
                    .OrderBy(p => p.DateSend)
                    .ToList();

                if (sortedParcels.Any())
                {
                    // Prepare the sorted information for display
                    var sortedInfo = string.Join(Environment.NewLine, sortedParcels.Select(p =>
                        $"Weight: {p.Weight}, DateSend: {p.DateSend}, DateCome: {p.DateCome}, Price: {p.Price}"
                    ));

                    MessageBox.Show("Sorted Parcels by DateSend:\n\n" + sortedInfo, "Sorted Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No parcels found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Error reading and sorting parcels. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Query the Parcels DbSet and sort by DateSend
                var sortedParcels = _context.Parcels
                    .OrderBy(p => p.DateSend)
                    .Where(p => p.Weight > 10)
                    .ToList();

                if (sortedParcels.Any())
                {
                    // Filter parcels by weight (> 10)
                    var heavyParcels = sortedParcels;//.Where(p => p.Weight > 10);

                    if (heavyParcels.Any())
                    {
                        // Prepare the filtered information for display
                        var filteredInfo = string.Join(Environment.NewLine, heavyParcels.Select(p =>
                            $"Weight: {p.Weight}, DateSend: {p.DateSend}, DateCome: {p.DateCome}, Price: {p.Price}"
                        ));

                        MessageBox.Show("Heavy Parcels (> 10kg):\n\n" + filteredInfo, "Filtered Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No heavy parcels (> 10kg) found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No parcels found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Error filtering parcels. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Query the Parcels DbSet and sort by DateSend
                var sortedParcels = _context.Parcels
                    .OrderBy(p => p.DateSend)
                    .Where(p => p.Price > 100)
                    .ToList();

                if (sortedParcels.Any())
                {
                    // Filter parcels by weight (> 10)
                    var expensiveParcelExists = sortedParcels;//.Where(p => p.Price > 100);

                    if (expensiveParcelExists.Any())
                    {
                        // Prepare the filtered information for display
                        var filteredInfo = string.Join(Environment.NewLine, expensiveParcelExists.Select(p =>
                            $"Weight: {p.Weight}, DateSend: {p.DateSend}, DateCome: {p.DateCome}, Price: {p.Price}"
                        ));

                        MessageBox.Show(" Expensive parcel exists (> 100):\n\n" + filteredInfo, "Filtered Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No expensive parcel  (> 100) found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No parcels found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Error filtering parcels. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Query the Parcels DbSet and sort by DateSend
                var sortedParcels = _context.Parcels
                    .OrderBy(p => p.DateSend)
                    .ToList();

                if (sortedParcels.Any())
                {
                    // Filter parcels by weight (> 10)

                    var averageWeight = sortedParcels.Average(p => p.Weight);

                    if (averageWeight != 0)
                    {

                        MessageBox.Show(" Average Weight:\n\n" + averageWeight, "Filtered Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(" Average Weight = 0 ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No parcels found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Error filtering parcels. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}