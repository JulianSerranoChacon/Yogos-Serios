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

    [SerializeField] private Image _sliderFelicidad;

    [SerializeField] private Image _sliderEcosistema;

    [SerializeField] private Image _sliderFauna;

    [SerializeField] private TMP_Text _diaActual;

    [SerializeField] private Image _infoIconGrande;

    [SerializeField] private Image _infoIconChica;

    [SerializeField] private Image _infoIconSal;


    private float _maxFelicidadWidth;
    private float _maxEcosistemaWidth;
    private float _maxFaunaWidth;

    private GameManager _gameManager;
    private RecursosManager _recursosManager;
    #endregion
    #region EfectoColoresBarras
    const float DIVISIONES1 = 4.0f;
    const float DIVISIONES2 = 2.0f;
    const float TIEMPO_FUNDIDO = 0.08f;
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
    public void ActualizarInterfaz()
    {        
        int din = _recursosManager.getDinero();
        _textoDinero.text = din.ToString() + "€";
        if(din >= Constants.BIEN_DE_DINERO) _textoDinero.color = Color.yellow;
        else _textoDinero.color = Color.red;

        float maxWidth = _sliderFelicidad.rectTransform.rect.width; // Asumiendo que las barras son del mismo ancho, usamos el de felicidad

        SetBarWidth(_sliderFelicidad, _recursosManager.getFelicidad(), _maxFelicidadWidth);
        SetBarWidth(_sliderEcosistema, _recursosManager.getEcosistema(), _maxEcosistemaWidth);
        SetBarWidth(_sliderFauna, _recursosManager.getFauna(), _maxFaunaWidth);

        _diaActual.text = "Semana: " + _gameManager.getTurno().ToString() + "/" + Constants.NUM_TURNOS_PARA_FIN;

        SetInfoIcons();
    }
    // Metodo para establecer el with de las barras segun su valor
    private void SetBarWidth(Image bar, double currentValue, float maxWidth)
    {
        float percentage = (float)currentValue / (float)Constants.MAX_REC;
        bar.rectTransform.sizeDelta = new Vector2(maxWidth * percentage, bar.rectTransform.sizeDelta.y);
    }
    // Metodo para mostrar los iconos en las lagunas donde hay eventos
    private void SetInfoIcons()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // Si es la escena mapa
        {
            // Comprobamos si la grande tiene eventos
            if (_gameManager.getLagunaTieneEventos(0)) _infoIconGrande.enabled = true;
            else _infoIconGrande.enabled = false;
            // Comprobamos si la chica tiene eventos
            if (_gameManager.getLagunaTieneEventos(1)) _infoIconChica.enabled = true;
            else _infoIconChica.enabled = false;
            // Comprobamos si la sal tiene eventos
            if (_gameManager.getLagunaTieneEventos(2)) _infoIconSal.enabled = true;
            else _infoIconSal.enabled = false;
        }
        else
        {
            _infoIconGrande.enabled = false;
            _infoIconChica.enabled = false;
            _infoIconSal.enabled = false;
        }

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
    }
}
