using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _coin;
    public MainUI MainUI;

    public int coin {
        get { return _coin; } 
        set
            {
                _coin = value;
                UpdateCoins();
            }
    }

    public void Awake()
    {
        Instance = this;
       UpdateCoins();
    }

    public void UpdateCoins()
    {
        MainUI.UpdateCoins();
    }

    public void CloseUI(GameObject UIElement)
    {
        UIElement.SetActive(false);
    }
    public void setCanInteractFalse(Interactable interactable)
    {
        interactable.canInteract = false;
    }
    public void setCanInteractTrue(Interactable interactable) 
    { 
        interactable.canInteract = true;
    }

}
