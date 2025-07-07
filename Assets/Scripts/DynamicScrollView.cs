using System.Collections.Generic;
using UnityEngine;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Sprite> levelButtonImg;

    private void Start()
    {
        foreach (Sprite levelButtonImg in levelButtonImg )
        {
            GameObject newLevelButton = Instantiate(prefab, scrollViewContent);

            if (newLevelButton.TryGetComponent<ScrollViewButton>(out ScrollViewButton buttonImgComponent))
            {
                buttonImgComponent.changeImage(levelButtonImg);
            }
        }
    }
}
