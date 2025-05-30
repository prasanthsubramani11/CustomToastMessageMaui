﻿using Toast.Services;

namespace Toast
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IToastService toastService;
        public MainPage(IToastService toastServices)
        {
            InitializeComponent();
            toastService = toastServices;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            toastService.LongAlert(CounterBtn.Text);
        }
    }

}
