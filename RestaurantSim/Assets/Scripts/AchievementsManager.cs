using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public List<GameObject> DishAchieveList;

    public void UpdateAchievements()
    {
        foreach (GameObject dishAchievement in DishAchieveList)
        {
            dishAchievement.GetComponent<DishAchievement>().UpdateAchievements();
            //dishAchievement.UpdateAchievements();
        }
    }
}
