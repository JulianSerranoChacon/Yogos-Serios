public class Evento
{
    #region atributos
    struct Opcion
    {
        string _textOpcion;
        int _din;
        double _eco;
        double _faun;
        double _feli;
    }
    Opcion[] opciones;      //Un array con todas las opciones que puede seleccionar el jugador junto a sus consecuencias
    string _texto;           //Un string con el texto que apaercerá en pantalla, explicando el evento
    #endregion

    public Evento(string texto, int numOpc, string[] textOpciones, int[] din, double[] eco, double[] faun, double[] feli)
    {
        opciones = new Opcion[numOpc];
        _texto = texto;
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
