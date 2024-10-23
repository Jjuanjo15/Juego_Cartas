namespace JuegoCartas
{
    public partial class FrmJuego : Form
    {
        Jugador jugador1, jugador2;
        public FrmJuego()
        {
            InitializeComponent();
            jugador1 = new Jugador();
            jugador2 = new Jugador();
        }

        private void btnRepartir_Click(object sender, EventArgs e)
        {
            jugador1.Repartir();
            jugador1.OrdenarCartas();
            jugador1.Mostrar(lvJugador1);

            jugador2.Repartir();
            jugador2.OrdenarCartas();
            jugador2.Mostrar(lvJugador2);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            switch (tcJugadores.SelectedIndex)
            {
                case 0:
                    mensaje = jugador1.ObtenerGrupos() +
                              $"\nPuntuación del Jugador 1: {jugador1.CalcularPuntuacion()}";
                    break;
                case 1:
                    mensaje = jugador2.ObtenerGrupos() +
                              $"\nPuntuación del Jugador 2: {jugador2.CalcularPuntuacion()}";
                    break;
            }
            MessageBox.Show(mensaje, "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
