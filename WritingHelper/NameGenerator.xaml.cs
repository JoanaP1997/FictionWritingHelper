using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WritingHelper
{
    public partial class NameGenerator : Page
    {
        public NameGenerator()
        {
            InitializeComponent();
        }

        private void NameGenerator_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<String> gender_list = new List<string>
            {
                "Male", "Female", "Non-Binary"
            };

            gender_combo_box.ItemsSource = gender_list;
            cob_combo_box.ItemsSource = getAllCountries();
            
        }

        private List<String> getAllCountries()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".FictionWritingHelper");
            var directories = Directory.GetDirectories(path);
            var countries = getNamesFromPaths(directories.ToList());
            return countries;
        }

        private List<String> getNamesFromPaths(List<String> directories)
        {
            List<String> names = new List<string>();
            foreach (var path in directories)
            {
                names.Add(path.Split('\\').Last());
            }

            return names;
        }

        private List<int> getAllYears(String country)
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".FictionWritingHelper", country);
            var fileNames = Directory.GetFiles(path);
            var years = getYearsFromPaths(fileNames.ToList());
            years.Reverse();
            return years;
        }

        private List<int> getYearsFromPaths(List<String> fileNames)
        {
            List<int> years = new List<int>();
            foreach (var fileName in fileNames)
            {
                years.Add(Int32.Parse(Regex.Match(fileName, @"\d+").Value));
            }
            return years;
        }

        private void Cob_combo_box_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dob_combo_box.ItemsSource = getAllYears((String)((ComboBox)sender).SelectedItem);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            String yob = ((int) dob_combo_box.SelectedItem).ToString();
            String cob = (String) cob_combo_box.SelectedItem;
            String sex = (String) gender_combo_box.SelectedItem;
            name_label.Content = generateName(yob, cob, sex);
        }

        private String generateName(String yob, String cob, String sex)
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".FictionWritingHelper", cob, ("yob" + yob +".txt"));
            List<String> listOfNamesRightGender = getMatchingNamesFromFile(path, sex);
            return chooseNameFromList(listOfNamesRightGender);
        }

        private List<String> getMatchingNamesFromFile(String path, String sex)
        {
            List<String> lines = System.IO.File.ReadAllLines(path).ToList();
            List<String> rightSex = new List<string>();
            foreach (var line in lines)
            {
                var splits = line.Split(',');
                if (splits[1].Contains(sex[0]))
                {
                    rightSex.Add(splits[0]);
                }
            }

            return rightSex;
        }

        private String chooseNameFromList(List<String> names)
        {
            Random rnd = new Random();
            var rand_index = rnd.Next(0, names.Count);
            return names[rand_index];
        }
    }
    
    
}