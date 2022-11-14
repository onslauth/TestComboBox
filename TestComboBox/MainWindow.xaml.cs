using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TestComboBox
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection< Tuple< int, string > > Items = new ObservableCollection< Tuple< int, string > >( );

        int? index = null;

        public MainWindow( )
        {
            this.InitializeComponent( );
        }

        private void myButton_Click( object sender, RoutedEventArgs e )
        {
            //myButton.Content = "Clicked";

            this.Items.Clear( );
            for ( int i = 0; i < 6; i++ )
            {
                this.Items.Add( new Tuple<int, string>( i, i.ToString( ) ) );
            }

            if ( this.index != null )
            {
                var item = this.Items.Where( i => i.Item1 == this.index ).FirstOrDefault( );
                if ( item != null )
                {
                    int index = this.Items.IndexOf( item );
                    this.ComboBox.SelectedIndex = index;
                }
            }


            if ( this.ComboBox.Visibility == Visibility.Visible )
            {
                this.ComboBox.Visibility = Visibility.Collapsed;
                myButton.Content = "Show";
            }
            else
            {
                this.ComboBox.Visibility = Visibility.Visible;
                myButton.Content = "Hide";
            }
        }

        private void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            var item = e.AddedItems[ 0 ] as Tuple< int, string >;
            this.index = item.Item1;
        }
    }
}
