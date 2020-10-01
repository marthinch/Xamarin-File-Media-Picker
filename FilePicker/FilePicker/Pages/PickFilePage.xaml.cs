using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilePicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickFilePage : ContentPage
    {
        public PickFilePage()
        {
            InitializeComponent();
        }

        private async void ButtonPickFile_Clicked(object sender, EventArgs e)
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                     { DevicePlatform.iOS, new[] { "com.adobe.pdf" } }, // or general UTType values
                     { DevicePlatform.Android, new[] { "application/pdf" } },
                     { DevicePlatform.UWP, new[] { ".pdf" } },
                     { DevicePlatform.Tizen, new[] { "*/*" } },
                     { DevicePlatform.macOS, new[] { "pdf"} }, // or general UTType values
            });

            var pickerResult = await Xamarin.Essentials.FilePicker.PickAsync(new PickOptions
            {
                FileTypes = customFileType,
                PickerTitle = "Pick a file"
            });

            if (pickerResult != null)
            {
                var readStreamFile = await pickerResult.OpenReadAsync();
                ImageFile.Source = ImageSource.FromStream(() => readStreamFile);
            }
        }
    }
}