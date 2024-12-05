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
