﻿using System;
using System.Linq;

namespace LINQ
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name="Alice", Height = 150},
                new Profile(){Name="Belle", Height = 160},
                new Profile(){Name="Caroline", Height = 155},
                new Profile(){Name="Daisy", Height = 166},
                new Profile(){Name="Eve", Height = 148}
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 160
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };
            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}.{profile.InchHeight}");
            
        }
    }
}
