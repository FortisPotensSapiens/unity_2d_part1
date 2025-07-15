using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelsDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private LevelDataSO[] levels;
    private int curLevelInd = 0;

    // Start is called before the first frame update
    void Start()
    {
        curLevelInd = 0;
        FillDescription();
    }

    private void FillDescription()
    {
        levelName.text = levels[curLevelInd].Name;
        coinsText.text = PlayerPrefs.GetInt("Level" + levels[curLevelInd].SceneInd + "Coins", 0).ToString();
    }

    private void ChangeLevel(int levelInd)
    {
        curLevelInd = levelInd;
        FillDescription();
    }

    public void NextLevel()
    {
        if (curLevelInd + 1 >= levels.Length)
            return;
        ChangeLevel(curLevelInd + 1);
    }

    public void PrevLevel()
    {
        if (curLevelInd - 1 < 0)
            return;
        ChangeLevel(curLevelInd - 1);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(levels[curLevelInd].SceneInd);
    }
}
