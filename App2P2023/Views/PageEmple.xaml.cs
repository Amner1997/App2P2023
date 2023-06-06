﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace App2P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEmple : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageEmple()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleados
            {
                Nombres = nombres.Text,
                Apellidos = apellidos.Text,
                FechaNac = fecha.Date,
                Telefono = telefono.Text,
            };

            if (await App.Instancia.AddEmple(emple) > 0)
            {
                await DisplayAlert("Aviso", "Empleado ingresado con exito", "OK");
            }
            else
                await DisplayAlert("Aviso", "a ocurrido un error", "OK");

        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {

            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if(photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}