using HoraSaida.ViewModel;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace HoraSaida
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    if (!EhValido())
        //        return;

        //    var diaSaidaAlmoco = (tpSaidaAlmoco.Time < tpEntrada.Time) ? 2 : 1;
        //    var entrada = new DateTime(2020, 1, 1, tpEntrada.Time.Hours, tpEntrada.Time.Minutes, 0);
        //    var saidaAlmoco = new DateTime(2020, 1, diaSaidaAlmoco, tpSaidaAlmoco.Time.Hours, tpSaidaAlmoco.Time.Minutes, 0);
        //    var primeiroIntervalo = saidaAlmoco - entrada;
        //    var cargaHoraria = ObterCargaHoraria();
        //    tpSaida.Time = tpRetornoAlmoco.Time.Add(TimeSpan.FromHours(cargaHoraria) - primeiroIntervalo);
        //}



        //private void btnReset_Clicked(object sender, EventArgs e)
        //{
        //    SetarHorariosPadrao();
        //}
    }
}
