using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pract14_3_4
{
    public partial class Form1 : Form
    {
        string filename = "people.txt";
        string filename2 = "people2.txt";
        private Queue<int> queue;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value; 
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }

            MessageBox.Show("Очередь заполнена!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (queue.Count == 0) 
            {
                MessageBox.Show("Очередь пуста!");
                return;
            }

            int number = queue.Dequeue(); 
            MessageBox.Show("Из очереди извлечено число: " + number);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Queue<int> numbers = new Queue<int>();
            string[] lines = File.ReadAllLines(filename2);


            foreach (string line2 in lines)
            {
                string[] parts = line2.Split(' ');

                numbers.Enqueue(int.Parse(parts[3]));
                if (numbers.Dequeue() >= 1)
                {
                    if (numbers.Dequeue() < 40)
                    {
                        listBox1.Items.Add(line2);
                    }
                    else
                    {
                        listBox2.Items.Add(line2);
                    }
                }
                else Console.WriteLine("Ошибка!");
            }
            Metod();
        }
        public void Metod()
        {
            queue = new Queue<int>();



            string[] lines2 = File.ReadAllLines(filename);


            List<Person> people = new List<Person>();

            foreach (string line in lines2)
            {
                string[] parts = line.Split(' ');

                string lastName = parts[0];
                string firstName = parts[1];
                string middleName = parts[2];
                int age = int.Parse(parts[3]);
                int weight = int.Parse(parts[4]);

                Person person = new Person(lastName, firstName, middleName, age, weight);
                people.Add(person);
            }


            people = people.OrderBy(p => p.Age).ToList();


            foreach (Person person in people)
            {
                string line = $"{person.LastName} {person.FirstName} {person.MiddleName} {person.Age} {person.Weight}";
                listBox3.Items.Add(line);
            }

        }
        public class Person
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }

            public Person(string lastName, string firstName, string middleName, int age, int weight)
            {
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
                Age = age;
                Weight = weight;
            }
        }
    }
}
