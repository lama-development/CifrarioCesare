using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CifrarioCesare
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ogni lettera del testo originale è sostituita, nel testo cifrato, dalla lettera che si trova un certo numero di posizioni dopo nell'alfabeto. Questo numero di posizioni è detto chiave.\n\nAutore: La Marca Davide", "Cifrario di Cesare", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // permette l'inserimento esclusivo di numeri nelle TextBox interessate 
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CryptInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // acquisizione messaggio da criptare
        }

        private void CryptKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            // acquisizione chiave di criptografia
        }

        private void DecryptInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // acquisizione messaggio da decriptare
        }

        private void DecryptKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            // acquisizione chiave di decriptografia
        }

        // bottone di esecuzione per criptografia
        private void CryptButton_Click(object sender, RoutedEventArgs e)
        {
            // controllo se almeno una delle due TextBox di input è vuota
            if (string.IsNullOrEmpty(CryptInput.Text) || string.IsNullOrEmpty(CryptKey.Text))
            {
                MessageBox.Show("É necessario completare tutti i campi.", "Cifrario di Cesare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // se tutte e due non sono vuote, procedo 
            else
            {
                try
                {
                    string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string input = CryptInput.Text.ToUpper();
                    string output = System.String.Empty;
                    int key = Int32.Parse(CryptKey.Text);

                    for (int i = 0; i < CryptInput.Text.Length; i++)
                    {
                        // se il carattere è una lettera dell'alfabeto procedo con l'algoritmo
                        if ((input[i] >= 'A') && (input[i] <= 'Z'))
                        {
                            // restituisce il valore dell'indice della prima occorrenza del carattere i
                            int j = alfabeto.IndexOf(input[i]);
                            // il nuovo carattere è calcolato sommando l'indice dell'occorrenza con la chiave
                            char ch = alfabeto[(j + key) % 26];
                            // infine aggiungo il carattere ottenuto alla mia stringa
                            output += ch;
                        }
                        // se invece non lo è, il carattere rimane invariato
                        else output += input[i];
                    }

                    // visualizzo il messaggio ottenuto nella TextBox
                    CryptOutput.Text = output;
                }

                catch
                {
                    MessageBox.Show("Si è verificato un errore nel programma.", "Cifrario di Cesare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CryptOutput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // finestra di output per il messaggio criptato
        }

        // bottone di esecuzione per decriptografia
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            // controllo se almeno una delle due TextBox di input è vuota
            if (string.IsNullOrEmpty(DecryptInput.Text) || string.IsNullOrEmpty(DecryptKey.Text))
            {
                MessageBox.Show("É necessario completare tutti i campi.", "Cifrario di Cesare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // se tutte e due non sono vuote, procedo 
            else
            {
                try
                {
                    string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string input = DecryptInput.Text.ToUpper();
                    string output = System.String.Empty;
                    int key = Int32.Parse(DecryptKey.Text);
                    char ch;

                    for (int i = 0; i < DecryptInput.Text.Length; i++)
                    {
                        // se il carattere è una lettera dell'alfabeto procedo con l'algoritmo
                        if ((input[i] >= 'A') && (input[i] <= 'Z'))
                        {
                            // restituisce il valore dell'indice della prima occorrenza del carattere i
                            int j = alfabeto.IndexOf(input[i]);
                            // il nuovo carattere è calcolato sottraendo l'indice dell'occorrenza con la chiave
                            if ((j - key) < 0) ch = alfabeto[26 - key];
                            else ch = alfabeto[j - key];
                            // infine aggiungo il carattere ottenuto alla mia stringa
                            output += ch;
                        }
                        // se invece non lo è, il carattere rimane invariato
                        else output += input[i];
                    }

                    // visualizzo il messaggio ottenuto nella TextBox
                    DecryptOutput.Text = output;
                }

                catch
                {
                    MessageBox.Show("Si è verificato un errore nel programma.", "Cifrario di Cesare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DecryptOutput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // finestra di output per il messaggio deccriptato
        }

        // bottone per cancellare tutte le TextBox inerenti alla fase di criptazione
        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            CryptInput.Text = null;
            CryptKey.Text = null;
            CryptOutput.Text = null;
        }

        // bottone per cancellare tutte le TextBox inerenti alla fase di decriptazione
        private void DeleteButton2_Click(object sender, RoutedEventArgs e)
        {
            DecryptInput.Text = null;
            DecryptKey.Text = null;
            DecryptOutput.Text = null;
        }

        // bottone per copiare l'output del messaggio criptato
        private void CopyButton1_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(CryptOutput.Text);
        }

        // bottone per copiare l'output del messaggio decriptato
        private void CryptButton2_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(DecryptOutput.Text);
        }
    }
}
