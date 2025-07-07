using UnityEngine;
using UnityEngine.UI;


public class ScrollViewButton : MonoBehaviour
{
    [SerializeField] private Image buttonImg;

    [SerializeField]
    private LevelData levelData;

    public LevelData GetLevelData()
    {
        return levelData;
    }

    public void changeImage(Sprite image)
    {
        buttonImg.sprite = image;
    }


    //TO DO
    //ADD FUNCTONALITY FO BUTTONS TO PRESS CARD OPEN FOR LEVEL DETAILS
}
