﻿using FilePicker.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilePicker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new PickMediaFilePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}