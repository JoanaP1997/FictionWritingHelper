using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileSanitizer
{
    internal class FileSanitizing
    {
        public static void Main(string[] args)
        {
            sanitizeFive();
        }

        private static void sanitizeOne()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "USA", ("yob" + "1990_" + ".txt"));
            String path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "USA", ("yob" + "1990" + ".txt"));
            List<String> lines = System.IO.File.ReadAllLines(path).ToList();
            List<String> newLines = new List<string>();
            foreach (var line in lines)
            {
                var newLine = replaceSpacesWithComma(line);
                newLines.Add(newLine);
            }
            File.WriteAllLines(path2, newLines);
            
        }

        private static String replaceSpacesWithComma(String inS)
        {
            String[] allParts = inS.Split(' ');
            String toReturn = "";
            foreach (var part in allParts)
            {
                if (!part.Equals(""))
                {
                    toReturn += (part + ",");
                }
            }
            return toReturn;
        }

        private static void sanitizeTwo()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "firstNames", "Germany", ("yob" + "1971" + ".txt"));
            String male = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "firstNames", "Germany", ("yob" + "1971_M" + ".txt"));
            String female = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "firstNames", "Germany", ("yob" + "1971_F" + ".txt"));
            List<String> maleLines = File.ReadAllLines(male).ToList();
            List<String> femaleLines = File.ReadAllLines(female).ToList();
            maleLines.RemoveAt(0);
            femaleLines.RemoveAt(0);
            List<String> newLines = new List<string>();
            foreach (var line in femaleLines)
            {
                var newL = Regex.Replace(line, @"\s+", "");
                var newLine = newL + ",F";
                newLines.Add(newLine);
            }
            foreach (var line in maleLines)
            {
                var newL = Regex.Replace(line, @"\s+", "");
                var newLine = newL + ",M";
                newLines.Add(newLine);
            }
            File.WriteAllLines(path, newLines);
            
        }

        private static void sanitizeThree()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "2005_" + ".txt"));
            String path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "2005" + ".txt"));
            List<String> names = File.ReadAllLines(path).ToList();
            List<String> newLines = new List<string>();
            newLines.Add(" ");
            foreach (var line in names)
            {
                //var newL = Regex.Replace(line, @"\s+", "");
                var newLine = replaceSpacesWithComma(line);
                newLines.Add(newLine);
            }
            File.WriteAllLines(path2, newLines);
        }

        private static void sanitizeFour()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "2002_" + ".txt"));
            String path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "2002" + ".txt"));
            List<String> names = File.ReadAllLines(path).ToList();
            List<String> newLines = new List<string>();
            newLines.Add(" ");
            foreach (var line in names)
            {
                var newLine = sanitize2002(line);
                newLines.Add(newLine);
            }
            File.WriteAllLines(path2, newLines);
        }

        private static String sanitize2002(String line)
        {
            var splits = line.Split(' ');
            String result = "";
            foreach (var split in splits)
            {
                if (!split.Contains("(") && !(split.Length < 1))
                {
                    result += split + ",";
                }
            }

            return result;
        }

        private static void sanitizeFive()
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "1915_" + ".txt"));
            String path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".FictionWritingHelper", "lastNames", "Germany", ("yob" + "1915" + ".txt"));
            List<String> names = File.ReadAllLines(path).ToList();
            List<String> newLines = new List<string>();
            newLines.Add(" ");
            foreach (var line in names)
            {
                var newLine = sanitize2002(line) + "6932415";
                newLines.Add(newLine);
            }
            File.WriteAllLines(path2, newLines);
        }
    }
}