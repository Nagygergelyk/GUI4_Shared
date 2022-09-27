using GUI4_Shared.Models;
using GUI4_Shared.ViewModels;
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
using System.Windows.Shapes;

namespace GUI4_Shared
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public EditorWindow()
        {
            InitializeComponent();
            // másik comment
        }
        public EditorWindow(Hero hero)
        {
            InitializeComponent();
            var vm = new EditorWindowViewModel();
            vm.Setup(hero);
            this.DataContext = vm;
        }

        private void Vm_EditedDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
