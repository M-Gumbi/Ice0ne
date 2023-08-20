using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WordScramble
{
    public partial class MainWindow : Window
    {
        private List<string> wordCollection = new List<string> { "apple", "banana", "orange", "grape", "strawberry" };
        private string currentWord;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordCollection.Count > 0)
            {
                int randomIndex = random.Next(wordCollection.Count);
                currentWord = wordCollection[randomIndex];
                ScrambledWordLabel.Content = ScrambleWord(currentWord);
                PlayButton.IsEnabled = false;
                GuessTextBox.Clear();
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string userGuess = GuessTextBox.Text.Trim();

            if (userGuess.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("CORRECT", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("INCORRECT", "Result", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            PlayButton.IsEnabled = true;
        }

        private string ScrambleWord(string word)
        {
            char[] characters = word.ToArray();
            for (int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }
            return new string(characters);
        }
    }
}
