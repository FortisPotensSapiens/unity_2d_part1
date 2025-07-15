using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Levels/New Level Data")]
public class LevelDataSO : ScriptableObject
{
    public string Name;
    public int SceneInd;
}
