using System.Collections;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public Dish dish;
    public TextMeshProUGUI remainingTime;
    public GameObject readyDish;
    public Transform spawnLocation;

    private float currentVelocity = 0;

    private float _timeElapsed = 0;

    public void Initiate()
    {
        _timeElapsed = 0;
        slider.value = 0;
        remainingTime.text = string.Empty;
    }
    public void Update()
    {
        // Update the slider & timer on each frame
        _timeElapsed += Time.deltaTime;
        float currentSliderValue = Mathf.SmoothDamp(slider.value, _timeElapsed / dish.time, ref currentVelocity, 100 * Time.deltaTime);
        slider.value = currentSliderValue;
        updateTimerText(dish.time - _timeElapsed);
    }

    private void updateTimerText(float currTime)
    {
        if (currTime >= 0) 
        {
            float minutes = Mathf.FloorToInt(currTime / 60);
            float seconds = Mathf.FloorToInt(currTime % 60);

            remainingTime.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        else
        {
            remainingTime.text = string.Format("{0:00} : {1:00}", 0, 0);
        }
    }

    public void onComplete()
    {
        print("LoadingBar onComplete");
        if (slider.value >= 1)
        {
            dish.amountCooked += 1;

            GameObject CompleteDish = Instantiate(readyDish, spawnLocation);
            CompleteDish.GetComponent<SpriteRenderer>().sprite = dish.finishedSprite;
            CompleteDish.GetComponent<ServingPickup>().dish = dish;
            CompleteDish.GetComponent<ServingPickup>().stoveTransform = spawnLocation;

            Destroy(gameObject);
        }
    }
}
