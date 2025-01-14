using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region parameters
    [SerializeField] private TMP_Text _textoDinero;

    [SerializeField] private GameObject _nextTurno;

    [SerializeField] private Image _sliderFelicidad;

    [SerializeField] private Image _sliderEcosistema;

    [SerializeField] private Image _sliderFauna;

    [SerializeField] private TMP_Text _diaActual;

    [SerializeField] private TMP_Text _EfectoDinero;

    [SerializeField] private DialogManager _dialogManager;

    [SerializeField] private GameObject sara;
    [SerializeField] private GameObject juan;

    private float _maxFelicidadWidth;
    private float _maxEcosistemaWidth;
    private float _maxFaunaWidth;

    private GameManager _gameManager;
    private RecursosManager _recursosManager;
    #endregion
    #region EfectoColoresBarras
    const float DIVISIONES1 = 8.0f;
    const float DIVISIONES2 = 5.0f;
    const float TIEMPO_FUNDIDO = 0.25f;
    public void SumaFel()
    {
        StartCoroutine(ChangeFel(0, 0.5f, 0));
    }
    public void RestaFel()
    {
        StartCoroutine(ChangeFel(1,0,0));
    }
    IEnumerator ChangeFel(float rObj, float gObj, float bObj)
    {
        float _r = _sliderFelicidad.color.r;
        float _g = _sliderFelicidad.color.g;
        float _b = _sliderFelicidad.color.b;

        float x = rObj - _sliderFelicidad.color.r;
        float y = gObj - _sliderFelicidad.color.g;
        float z = bObj - _sliderFelicidad.color.r;
        for (int i = 1; i < DIVISIONES2; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
            _sliderFelicidad.color = new Color(_sliderFelicidad.color.r + (x / DIVISIONES2), _sliderFelicidad.color.g + (y / DIVISIONES2), _sliderFelicidad.color.b + (z / DIVISIONES2));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
        _sliderFelicidad.color = new Color(rObj, gObj, bObj);

        for (int i = 1; i < DIVISIONES1; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
            _sliderFelicidad.color = new Color(_sliderFelicidad.color.r - (x / DIVISIONES1), _sliderFelicidad.color.g - (y / DIVISIONES1), _sliderFelicidad.color.b - (z / DIVISIONES1));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
        _sliderFelicidad.color = new Color(_r, _g, _b);
    }
    public void SumaEco()
    {
        StartCoroutine(ChangeEco(0, 0.5f, 0));
    }
    public void RestaEco()
    {
        StartCoroutine(ChangeEco(1, 0, 0));
    }
    IEnumerator ChangeEco(float rObj, float gObj, float bObj)
    {
        float _r = _sliderEcosistema.color.r;
        float _g = _sliderEcosistema.color.g;
        float _b = _sliderEcosistema.color.b;

        float x = rObj - _sliderEcosistema.color.r;
        float y = gObj - _sliderEcosistema.color.g;
        float z = bObj - _sliderEcosistema.color.r;
        for (int i = 1; i < DIVISIONES2; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
            _sliderEcosistema.color = new Color(_sliderEcosistema.color.r + (x / DIVISIONES2), _sliderEcosistema.color.g + (y / DIVISIONES2), _sliderEcosistema.color.b + (z / DIVISIONES2));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
        _sliderEcosistema.color = new Color(rObj, gObj, bObj);

        for (int i = 1; i < DIVISIONES1; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
            _sliderEcosistema.color = new Color(_sliderEcosistema.color.r - (x / DIVISIONES1), _sliderEcosistema.color.g - (y / DIVISIONES1), _sliderEcosistema.color.b - (z / DIVISIONES1));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
        _sliderEcosistema.color = new Color(_r, _g, _b);
    }
    public void SumaFau()
    {
        StartCoroutine(ChangeFau(0, 0.5f, 0));
    }
    public void RestaFau()
    {
        StartCoroutine(ChangeFau(1, 0, 0));
    }
    IEnumerator ChangeFau(float rObj, float gObj, float bObj)
    {
        float _r = _sliderFauna.color.r;
        float _g = _sliderFauna.color.g;
        float _b = _sliderFauna.color.b;

        float x = rObj - _sliderFauna.color.r;
        float y = gObj - _sliderFauna.color.g;
        float z = bObj - _sliderFauna.color.r;
        for (int i = 1; i < DIVISIONES2; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
            _sliderFauna.color = new Color(_sliderFauna.color.r + (x / DIVISIONES2), _sliderFauna.color.g + (y / DIVISIONES2), _sliderFauna.color.b + (z / DIVISIONES2));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES2);
        _sliderFauna.color = new Color(rObj, gObj, bObj);

        for (int i = 1; i < DIVISIONES1; i++)
        {
            yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
            _sliderFauna.color = new Color(_sliderFauna.color.r - (x / DIVISIONES1), _sliderFauna.color.g - (y / DIVISIONES1), _sliderFauna.color.b - (z / DIVISIONES1));
        }
        yield return new WaitForSeconds(TIEMPO_FUNDIDO / DIVISIONES1);
        _sliderFauna.color = new Color(_r, _g, _b);
    }
    #endregion
    public void ActualizarInterfaz(bool smooth = false)
    {        
        int din = _recursosManager.getDinero();
        int prevDin = _recursosManager.getPrevDinero();
        _textoDinero.text = din.ToString() + "€";
        if(din >= Constants.BIEN_DE_DINERO) _textoDinero.color = Color.yellow;
        else _textoDinero.color = Color.red;        
        if(prevDin != 0)
        {
            _EfectoDinero.text = prevDin.ToString() + "€";
            if (prevDin > 0) _EfectoDinero.color = Color.green;
            else _EfectoDinero.color = Color.red;
            _EfectoDinero.GetComponent<Animator>().Play("EfectoDinero");
        }

        float maxWidth = _sliderFelicidad.rectTransform.rect.width; // Asumiendo que las barras son del mismo ancho, usamos el de felicidad

        SetBarWidth(_sliderFelicidad, _recursosManager.getFelicidad(), _recursosManager.getPrevFelicidad(), _maxFelicidadWidth, smooth);
        SetBarWidth(_sliderEcosistema, _recursosManager.getEcosistema(), _recursosManager.getPrevEcosistema(), _maxEcosistemaWidth, smooth);
        SetBarWidth(_sliderFauna, _recursosManager.getFauna(), _recursosManager.getPrevFauna(), _maxFaunaWidth, smooth);

        _diaActual.text = "Semana: " + _gameManager.getTurno().ToString() + "/" + Constants.NUM_TURNOS_PARA_FIN;        
    }
    // Metodo para establecer el with de las barras segun su valor
    private void SetBarWidth(Image bar, double currentValue, double prevValue, float maxWidth, bool smooth)
    {
        
        float percentage = (float)currentValue / (float)Constants.MAX_REC;
        if (smooth)
        {
            float percentageAct = (float)prevValue / (float)Constants.MAX_REC;
            StartCoroutine(BarWidthSmooth(bar, percentage, percentageAct, maxWidth));
        }
        else bar.rectTransform.sizeDelta = new Vector2(maxWidth * percentage, bar.rectTransform.sizeDelta.y);                        
    }
    IEnumerator BarWidthSmooth(Image bar, float percentage, float percentageAct, float maxWidth)
    {
        float diff = percentageAct - percentage;
        for (int i = 1; i < DIVISIONES2+ DIVISIONES1; i++)
        {
            yield return new WaitForSeconds((2*TIEMPO_FUNDIDO) / (DIVISIONES2+DIVISIONES1));
            bar.rectTransform.sizeDelta = new Vector2(maxWidth * (percentageAct - ((diff/(DIVISIONES2 + DIVISIONES1)) * i)), bar.rectTransform.sizeDelta.y);
        }
        yield return new WaitForSeconds((2 * TIEMPO_FUNDIDO) / (DIVISIONES2 + DIVISIONES1));
        bar.rectTransform.sizeDelta = new Vector2(maxWidth * percentage, bar.rectTransform.sizeDelta.y);
    }

    public void nextLine()
    {
        _dialogManager.nextLine();
    }

    public bool getInDialgue()
    {
        return _dialogManager.getDialogue();
    }
    public void addDialogue(string[] dialogo)
    {
        _dialogManager.addDialogue(dialogo);
    }
    public void addDialogue(int turno)
    {
        _dialogManager.addDialogue(GameManager.Instance.getWeekDialogue(turno));
    }
    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.AssignUIManager(this);
        _recursosManager = _gameManager.getResMan();

        _maxFelicidadWidth = _sliderFelicidad.rectTransform.rect.width;
        _maxEcosistemaWidth = _sliderEcosistema.rectTransform.rect.width;
        _maxFaunaWidth = _sliderFauna.rectTransform.rect.width;

        ActualizarInterfaz();

        if (_gameManager.getTurno() == 0 && !_gameManager.getDialogoInicial())
        {
            chooseCharacter(0);
            _dialogManager.addDialogue(_gameManager.GetDialogos().dialogoInicial);
            _gameManager.setDialogoInicial();
        }
    }
    public void setVisibleNext()
    {
        _nextTurno.SetActive(true);
    }

    /// <summary>
    /// 1 = Sara
    /// 0 = Juan
    /// </summary>
    /// <param name="personaje"></param>
    public void chooseCharacter(int personaje)
    {
        switch (personaje) 
        { 
            case 1:
                sara.SetActive(true);
                break;
            case 0:
                juan.SetActive(true);
                break;
        }
    }
    public void dialogEnd()
    {
        sara.SetActive(false);
        juan.SetActive(false);
    }
}
