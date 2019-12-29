using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1_test
{
    class ToDetectAttribute : Attribute { }

    #region MyClasses
    [ToDetect]
    class Bot
    {
        public int BotID { get; set; }
    }

    [ToDetect]
    class Dog : Bot
    {
        public int Name { get; set; }
    }

    [ToDetect]
    class Character
    {
        public int BirthYear { get; set; }
        public int RelationNumber { get; set; }
        public string Name { get; set; }
    }

    [ToDetect]
    class Teacher : Character
    {
        public double MarkMyProfessorRatings{ get; set; }
        public int StudentsNumber { get; set; }
    }
    #endregion

    [ToDetect]
    public class Student
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Property3 { get; set; }
        public int Property4 { get; set; }
        public int Property5 { get; set; }
    }

    [ToDetect]
    public class Vadallat
    {
        public int Property1 { get; set; }
    }

    [ToDetect]
    public class Szamitogep
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Property5 { get; set; }
    }



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetCustomAttribute<ToDetectAttribute>() != null);
            foreach (var item in types)
                selector.Items.Add(item.Name);
        }

        private void FetchProps_Click(object sender, RoutedEventArgs e)
        {
            // PROPERTIES
            // clear prev. values
            propertiesListBox.Items.Clear();

            // add new values
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToString() == selector.SelectedItem.ToString())
                .FirstOrDefault();

            foreach (var item in types.GetProperties())
                propertiesListBox.Items.Add(item.Name);

            // ========================================================================

            // METHODS
            methodsListBox.Items.Clear();

            foreach (var item in types.GetMethods())
                methodsListBox.Items.Add(item.Name);
        }
    }
}
