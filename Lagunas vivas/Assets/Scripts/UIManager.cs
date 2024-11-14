using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region parameters
    [SerializeField] private Image _sliderDinero;

    [SerializeField] private Image _sliderFelicidad;

    [SerializeField] private Image _sliderEcosistema;

    [SerializeField] private Image _sliderFauna;
    private GameManager _gameManager;
    private RecursosManager _recursosManager;
    #endregion

    public void ActualizarInterfaz()
    {
        _sliderDinero.fillAmount = _recursosManager.getDinero() / (float)Constants.MAX_DINERO;
        _sliderFelicidad.fillAmount = (float)_recursosManager.getFelicidad() / (float)Constants.MAX_REC;
        _sliderEcosistema.fillAmount = (float)_recursosManager.getEcosistema() / (float)Constants.MAX_REC;
        _sliderFauna.fillAmount = (float)_recursosManager.getFauna() / (float)Constants.MAX_REC;
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
