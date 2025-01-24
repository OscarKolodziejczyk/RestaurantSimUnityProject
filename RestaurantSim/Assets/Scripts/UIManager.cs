using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Stack<GameObject> UIstack = new Stack<GameObject>();
    public GameObject mainMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveUI();
            print("Escape Pressed");
        }
    }

    public void AddUI(GameObject UIElement)
    {
        UIstack.Push(UIElement);
        UIElement.gameObject.SetActive(true);
    }
    public void RemoveUI()
    {
        if (UIstack.Count > 0) {
            GameObject currUI = UIstack.Pop();
            currUI.SetActive(false);
        }
        else
        {
            ActivateMainMenu();
        }
    }
    public void ActivateMainMenu()
    {

        AddUI(mainMenu);
    }

    public void ResetUI()
    {
        while (UIstack.Count > 0)
        {
            RemoveUI();
        }
    }
}
