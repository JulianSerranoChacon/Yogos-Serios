public class Evento
{
    #region atributos
     public struct Opcion
    {
        public string _textOpcion;
        public int _din;
        public double _eco;
        public double _faun;
        public double _feli;
    }
    public Opcion[] opciones;      //Un array con todas las opciones que puede seleccionar el jugador junto a sus consecuencias
    public string _textoPrincipal;           //Un string con el texto que apaercer� en pantalla, explicando el evento
    public int _numOpciones;
    #endregion

    public Evento(string texto, int numOpc, string[] textOpciones, int[] din, double[] eco, double[] faun, double[] feli)
    {
        opciones = new Opcion[numOpc];
        _textoPrincipal = texto;
        _numOpciones = numOpc;
        for(int i = 0; i < numOpc; i++)
        {
            opciones[i]._textOpcion = textOpciones[i];
            opciones[i]._din = din[i];
            opciones[i]._eco = eco[i];
            opciones[i]._faun = faun[i];
            opciones[i]._feli = feli[i];
        }
    }
}
