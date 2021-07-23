using System.Windows;
using System.Windows.Input;


namespace GarticBot
{
    /// <summary>
    /// Interaction logic for DrawingRectSelector.xaml
    /// </summary>
    public partial class DrawingRectSelector : Window
    {
        public DrawingRectSelector()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
