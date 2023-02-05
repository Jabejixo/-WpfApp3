using System;
using System.Collections;
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

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        int zamer;
        Random random = new Random();
        int element;
        int playerOrRoboRandom = 1;
        int countCkick;
        bool win = false;
        List <Button> buttons= new List <Button>();
        public MainWindow()
        {
            InitializeComponent();
            buttons.Add(Button1);
            buttons.Add(Button2);
            buttons.Add(Button3);
            buttons.Add(Button4);
            buttons.Add(Button5);
            buttons.Add(Button6);
            buttons.Add(Button7);
            buttons.Add(Button8);
            buttons.Add(Button9);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            countCkick++;
            if (playerOrRoboRandom == 0)
            {
                ((Button)sender).Content = "X";
                ((Button)sender).IsEnabled = false;    
                winner();
                if (win == false & countCkick < 9) AI();
            }
            else if (playerOrRoboRandom == 1)
            {
                ((Button)sender).Content = "0";
                ((Button)sender).IsEnabled = false;
                winner();
                if (win == false & countCkick < 9) AI();
            }
        }
        private void winner()
        {
            if (((string)Button1.Content == "0" && (string)Button2.Content == "0" && (string)Button3.Content == "0")
                || ((string)Button4.Content == "0" && (string)Button5.Content == "0" && (string)Button6.Content == "0")
                || ((string)Button7.Content == "0" && (string)Button8.Content == "0" && (string)Button9.Content == "0")
                || ((string)Button1.Content == "0" && (string)Button5.Content == "0" && (string)Button9.Content == "0")
                || ((string)Button3.Content == "0" && (string)Button5.Content == "0" && (string)Button7.Content == "0")
                || ((string)Button1.Content == "0" && (string)Button4.Content == "0" && (string)Button7.Content == "0")
                || ((string)Button2.Content == "0" && (string)Button5.Content == "0" && (string)Button8.Content == "0")
                || ((string)Button3.Content == "0" && (string)Button6.Content == "0" && (string)Button9.Content == "0"))
            {
                win = true;
                Winner.Text = "ПОБЕДИЛ НОЛИК";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            if (((string)Button1.Content == "X" && (string)Button2.Content == "X" && (string)Button3.Content == "X")
                || ((string)Button4.Content == "X" && (string)Button5.Content == "X" && (string)Button6.Content == "X")
                || ((string)Button7.Content == "X" && (string)Button8.Content == "X" && (string)Button9.Content == "X")
                || ((string)Button1.Content == "X" && (string)Button5.Content == "X" && (string)Button9.Content == "X")
                || ((string)Button3.Content == "X" && (string)Button5.Content == "X" && (string)Button7.Content == "X")
                || ((string)Button1.Content == "X" && (string)Button4.Content == "X" && (string)Button7.Content == "X")
                || ((string)Button2.Content == "X" && (string)Button5.Content == "X" && (string)Button8.Content == "X")
                || ((string)Button3.Content == "X" && (string)Button6.Content == "X" && (string)Button9.Content == "X"))
            {
                win = true;
                Winner.Text = "ПОБЕДИЛ КРЕСТИК";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            if (((countCkick % 9) == 0 && countCkick != 0) & win == false)
            {
                Winner.Text = "Ничья";
            }
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            countCkick = 0;
            win = false;
            Winner.Text = "КРЕСТИКИ-НОЛИКИ";
            switch (playerOrRoboRandom)
            {
                case 0:
                    playerOrRoboRandom = 1;
                    break;
                case 1:
                    playerOrRoboRandom = 0;
                    break;
            }
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button9.IsEnabled = true;
            Button1.Content = "";
            Button2.Content = "";
            Button3.Content = "";
            Button4.Content = "";
            Button5.Content = "";  
            Button6.Content = "";
            Button7.Content = "";  
            Button8.Content = "";
            Button9.Content = "";
            if (playerOrRoboRandom == 1) AI();
        }
        private void AI()
        {
            zamer++;
            try
            {
                element = random.Next(0, 8);
                if (playerOrRoboRandom == 0 & (string)buttons[element].Content == "")
                {
                    countCkick++;
                    buttons[element].Content = "0";
                    buttons[element].IsEnabled = false;
                    winner();
                }
                else if (playerOrRoboRandom == 1 & (string)buttons[element].Content == "")
                {
                    countCkick++;
                    buttons[element].Content = "X";
                    buttons[element].IsEnabled = false;
                    winner();
                }
                else
                {
                    AI();
                }
            }
            catch (StackOverflowException)
            {
                winner();
                if (win == false) Winner.Text = "НИЧЬЯ";
            }
        }
    }
}
