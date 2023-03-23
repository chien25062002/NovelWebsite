﻿using System.Text.RegularExpressions;

namespace NovelWebsite.Extensions
{
    public class StringExtensions
    {
        public static string Slugify(string phrase)
        {
            string str = Regex.Replace(phrase, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

    }
}