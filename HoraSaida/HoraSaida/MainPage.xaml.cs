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
            SetarHorariosPadrao();
        }

        private void SetarHorariosPadrao()
        {
            tpEntrada.Time = TimeSpan.FromHours(8);
            tpSaidaAlmoco.Time = TimeSpan.FromHours(12);
            tpRetornoAlmoco.Time = TimeSpan.FromHours(13);
            tpSaida.Time = TimeSpan.FromHours(17);
            tpCargaHoraria.Text = "8";
        }

        private double ObterCargaHoraria()
        {
            if (double.TryParse(tpCargaHoraria.Text, out double cH))
                return cH;
            return 8;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!EhValido())
                return;

            var diaSaidaAlmoco = (tpSaidaAlmoco.Time < tpEntrada.Time) ? 2 : 1;
            var entrada = new DateTime(2020, 1, 1, tpEntrada.Time.Hours, tpEntrada.Time.Minutes, 0);
            var saidaAlmoco = new DateTime(2020, 1, diaSaidaAlmoco, tpSaidaAlmoco.Time.Hours, tpSaidaAlmoco.Time.Minutes, 0);
            var primeiroIntervalo = saidaAlmoco - entrada;
            var cargaHoraria = ObterCargaHoraria();
            tpSaida.Time = tpRetornoAlmoco.Time.Add(TimeSpan.FromHours(cargaHoraria) - primeiroIntervalo);
        }

        private bool EhValido()
        {
            var cargaHoraria = ObterCargaHoraria();
            if (cargaHoraria <= 4 || cargaHoraria >= 14)
            {
                DisplayAlert("Carga horária", "Carga horária deve ser entre 4 e 14 horas", "OK");
                return false;
            }

            return true;
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            SetarHorariosPadrao();
        }
    }
}
