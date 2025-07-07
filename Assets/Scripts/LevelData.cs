using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "MapLevel/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public float highScore;
    public int difficulty;
    public string penalties;
    public string climate;
    public string traffic;
    public string revenue;
    public string levelIndex;
    public Sprite flagSprite;
}
