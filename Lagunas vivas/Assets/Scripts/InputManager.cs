using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {

        UIManager _myUI = GameManager.Instance.getUIManager();
        if (context.started && _myUI.getInDialgue())
            return;

        if (context.started)
        {
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue())); if (rayHit.collider)
            {
                GameManager.Instance.sendEvent(rayHit.collider.gameObject);
            }
        }
        else if (context.canceled)
        {

            if (_myUI.getInDialgue())
            {
                _myUI.nextLine();
                return;
            }
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (rayHit.collider)
            {
                GameManager.Instance.HandleClick(rayHit.collider.gameObject);
            }
        }
    }
}
