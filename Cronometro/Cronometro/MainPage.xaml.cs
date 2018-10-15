using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;

namespace Cronometro
{
    public partial class MainPage : ContentPage
    {
        TimeSpan tempo = new TimeSpan();
        List<TimeSpan> listTempos = new List<TimeSpan>();
        Boolean iniciado = false;

        public MainPage()
        {
            InitializeComponent();
        }


        private void Temporizador(object sender, EventArgs e)
        {
            btIniciar.Text = iniciado ? "Iniciar" : "Zerar";

            if (!iniciado)
            {
                iniciado = true;
                TimeSpan incrementoTempo = new TimeSpan();
                Device.StartTimer(new TimeSpan(0, 0, 0, 1), () =>
                {
                    if (iniciado)
                    {
                        tempo = tempo + incrementoTempo.Add(new TimeSpan(0, 0, 0, 1));
                        lbTime.Text = string.Format("{0:hh\\:mm\\:ss}", tempo);
                    }
                    return true;
                });
            }
            else
            {
                iniciado = false;
                tempo = new TimeSpan();
                listTempos = new List<TimeSpan>();
                lbTime.Text = "00:00:00";
            }

        }

        private void Volta(object sender, EventArgs e)
        {
            listTempos.Add(tempo);
            lbLast.Text = string.Format("{0:hh\\:mm\\:ss}", listTempos[listTempos.Count - 1]);

            var avgTimes = new TimeSpan(Convert.ToInt64(listTempos.Average(t => t.Ticks)));

            lbAVG.Text = string.Format("{0:hh\\:mm\\:ss}", avgTimes);
            tempo = new TimeSpan();
        }
        
    }
}
