namespace JuegoCartas
{
    public class Jugador
    {
        private const int TOTAL_CARTAS = 10;
        private Carta[] cartas;
        private Random r = new Random();

        public void Repartir()
        {
            cartas = new Carta[TOTAL_CARTAS];
            for (int i = 0; i < TOTAL_CARTAS; i++)
            {
                cartas[i] = new Carta(r);
            }
        }

        public void Mostrar(ListView lv)
        {
            lv.Items.Clear();
            foreach (Carta carta in cartas)
            {
                carta.mostrar(lv);
            }
        }

        public String ObtenerGrupos()
        {
            String mensaje = "No se encontraron grupos";
            int[] contadores = new int[Enum.GetValues(typeof(NombreCarta)).Length];
            foreach (Carta carta in cartas)
            {
                contadores[(int)carta.ObtenerNombre()]++;
            }
            bool hayGrupos = false;
            int posicionContador = 0;
            foreach (int contador in contadores)
            {
                if (contador >= 2)
                {
                    if (!hayGrupos)
                    {
                        mensaje = "Se encontraron los siguientes grupos:\n";
                        hayGrupos = true;
                    }
                    mensaje +=
                    Enum.GetValues(typeof(Grupo)).GetValue(contador).ToString() +
                    " de " +
                    Enum.GetValues(typeof(NombreCarta)).GetValue(posicionContador).ToString() +
                    "\n";
                }
                posicionContador++;
            }
            return mensaje;
        }

        public void OrdenarCartas()
        {
            for (int i = 0; i < cartas.Length - 1; i++)
            {
                for (int j = 0; j < cartas.Length - i - 1; j++)
                {
                    if (cartas[j].ObtenerPinta() > cartas[j + 1].ObtenerPinta())
                    {
                        Intercambiar(j, j + 1);
                    }
                    else if (cartas[j].ObtenerPinta() == cartas[j + 1].ObtenerPinta() && cartas[j].ObtenerNombre() > cartas[j + 1].ObtenerNombre())
                    {
                        Intercambiar(j, j + 1);
                    }
                }
            }
        }

        private void Intercambiar(int i, int j)
        {
            Carta temp = cartas[i];
            cartas[i] = cartas[j];
            cartas[j] = temp;
        }

        public int CalcularPuntuacion()
        {
            int puntuacionTotal = 0;
            foreach (Carta carta in cartas)
            {
                puntuacionTotal += carta.Valor;
            }
            return puntuacionTotal;
        }
    }
}
