using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilePicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickMultipleFilePage : ContentPage
    {
        public PickMultipleFilePage()
        {
            InitializeComponent();
        }

        private async void ButtonPickMultipleFile_Clicked(object sender, EventArgs e)
        {
            var pickerResult = await Xamarin.Essentials.FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick multiple file image"
            });

            if (pickerResult != null)
            {
                var listImageSource = new List<ImageSource>();

                foreach (var image in pickerResult)
                {
                    var readStreamFile = await image.OpenReadAsync();
                    listImageSource.Add(ImageSource.FromStream(() => readStreamFile));
                }

                CollectionViewFiles.ItemsSource = listImageSource;
            }
        }
    }
}