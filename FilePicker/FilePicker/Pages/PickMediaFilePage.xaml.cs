using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilePicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickMediaFilePage : ContentPage
    {
        public PickMediaFilePage()
        {
            InitializeComponent();
        }

        private async void ButtonPickMediaFile_Clicked(object sender, EventArgs e)
        {
            var mediaPickerResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            if (mediaPickerResult != null)
            {
                var readStreamFile = await mediaPickerResult.OpenReadAsync();
                ImageFile.Source = ImageSource.FromStream(() => readStreamFile);
            }
        }

        private async void ButtonOpenCamera_Clicked(object sender, EventArgs e)
        {
            var mediaPickerResult = await MediaPicker.CapturePhotoAsync();
            if (mediaPickerResult != null)
            {
                var readStreamFile = await mediaPickerResult.OpenReadAsync();
                ImageFile.Source = ImageSource.FromStream(() => readStreamFile);
            }
        }
    }
}