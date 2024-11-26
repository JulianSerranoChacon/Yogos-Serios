using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region parameters
    [SerializeField] private TMP_Text _textoDinero;    

    [SerializeField] private Image _sliderFelicidad;

    [SerializeField] private Image _sliderEcosistema;

    [SerializeField] private Image _sliderFauna;

    [SerializeField] private TMP_Text _diaActual;
    private GameManager _gameManager;
    private RecursosManager _recursosManager;
    #endregion
    public void ActualizarInterfaz()
    {        
        int din = _recursosManager.getDinero();
        _textoDinero.text = din.ToString() + "�";
        if(din >= Constants.BIEN_DE_DINERO) _textoDinero.color = Color.green;
        else if (din >= Constants.OK_DE_DINERO) _textoDinero.color = Color.yellow;
        else _textoDinero.color = Color.red;
        _sliderFelicidad.fillAmount = (float)_recursosManager.getFelicidad() / (float)Constants.MAX_REC;
        _sliderEcosistema.fillAmount = (float)_recursosManager.getEcosistema() / (float)Constants.MAX_REC;
        _sliderFauna.fillAmount = (float)_recursosManager.getFauna() / (float)Constants.MAX_REC;

        _diaActual.text = "Semana: " + _gameManager.getTurno().ToString() + "/" + Constants.NUM_TURNOS_PARA_FIN;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.AssignUIManager(this);
        _recursosManager = _gameManager.getResMan();        
        ActualizarInterfaz();
    }
}
