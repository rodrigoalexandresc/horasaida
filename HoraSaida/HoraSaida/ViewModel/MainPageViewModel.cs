using System;
using Xamarin.Forms;

namespace HoraSaida.ViewModel
{
    public class MainPageViewModel : NotificacaoBase
    {
        public MainPageViewModel()
        {
            RestaurarValoresPadrao();
        }

        private string _cargaHoraria;

        public string CargaHoraria
        {
            get { return _cargaHoraria; }
            set { _cargaHoraria = value; Notificar(); }
        }

        private TimeSpan _entrada;

        public TimeSpan Entrada
        {
            get { return _entrada; }
            set { _entrada = value; Notificar(); }
        }

        private TimeSpan _saidaAlmoco;

        public TimeSpan SaidaAlmoco
        {
            get { return _saidaAlmoco; }
            set { _saidaAlmoco = value; Notificar(); }
        }

        private TimeSpan _retornoAlmoco;

        public TimeSpan RetornoAlmoco
        {
            get { return _retornoAlmoco; }
            set { _retornoAlmoco = value; Notificar(); }
        }

        private TimeSpan _saida;

        public TimeSpan Saida
        {
            get { return _saida; }
            set { _saida = value; Notificar(); }
        }

        private string _mensagemValidacao;

        public string MensagemValidacao
        {
            get { return _mensagemValidacao; }
            set { _mensagemValidacao = value; Notificar(); }
        }

        private bool _invalido;

        public bool Invalido
        {
            get { return _invalido; }
            set { _invalido = value; Notificar(); }
        }

        public Command CalculaHoraSaidaCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (!EhValido())
                        return;

                    var diaSaidaAlmoco = (SaidaAlmoco < Entrada) ? 2 : 1;
                    var entrada = new DateTime(2020, 1, 1, Entrada.Hours, Entrada.Minutes, 0);
                    var saidaAlmoco = new DateTime(2020, 1, diaSaidaAlmoco, SaidaAlmoco.Hours, SaidaAlmoco.Minutes, 0);
                    var primeiroIntervalo = saidaAlmoco - entrada;
                    var cargaHoraria = ObterCargaHoraria();
                    Saida = RetornoAlmoco.Add(TimeSpan.FromHours(cargaHoraria) - primeiroIntervalo);
                });
            }
        }

        public Command RestaurarCommand
        {
            get
            {
                return new Command(() =>
                {
                    RestaurarValoresPadrao();
                });
            }
        }

        private double ObterCargaHoraria()
        {
            if (double.TryParse(CargaHoraria, out double cH))
                return cH;
            return 8;
        }

        private void RestaurarValoresPadrao()
        {
            Entrada = TimeSpan.FromHours(8);
            SaidaAlmoco = TimeSpan.FromHours(12);
            RetornoAlmoco = TimeSpan.FromHours(13);
            Saida = TimeSpan.FromHours(17);
            CargaHoraria = "8";
        }

        private bool EhValido()
        {
            Invalido = false;
            var cargaHoraria = ObterCargaHoraria();
            if (cargaHoraria < 4 || cargaHoraria > 14)
            {
                MensagemValidacao = "Carga horária deve ser entre 4 e 14 horas";
                Invalido = true;
            }

            return !Invalido;
        }
    }
}
