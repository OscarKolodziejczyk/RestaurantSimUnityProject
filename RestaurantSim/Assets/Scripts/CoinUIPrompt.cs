using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CoinUIPrompt : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI textBox;
    private Color imageColor = Color.white;
    private Color textColor = Color.white;
    private Vector3 vectorY = Vector3.zero;

    public void CoinUIExec(Dish dish)
    {
        //this.enabled = true;
        vectorY = image.gameObject.transform.position;
        textBox.text = $"+{dish.price}";
        textColor = textBox.color;
        gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        imageColor.a -= 0.02f;
        textColor.a -= 0.02f;
        image.color = imageColor;
        textBox.color= textColor;

        vectorY.y += 0.07f;
        image.gameObject.transform.position = vectorY; //TODO, Buggy needs work

        if (image.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
