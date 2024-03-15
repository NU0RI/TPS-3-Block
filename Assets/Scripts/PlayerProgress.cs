using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;
    public TextMeshProUGUI levelValueTMP;
    public RectTransform experienceValueRectTransform;
    private int _LevelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        DrawUI();
        SetLevel(_LevelValue);
    }
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_LevelValue += 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _LevelValue = value;

        var currentLevel = levels[_LevelValue - 1];
        _experienceTargetValue = levels[_LevelValue - 1].experienceForTheNextLevel;
        GetComponent<BulletCaster>().damage = currentLevel.BulletDamage;
        var grenadeCaster = GetComponent<GrenadeCaster>();
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;

        grenadeCaster.enabled = true;
        if (currentLevel.grenadeDamage < 0)
        {
            grenadeCaster.enabled = false;
        }
    }
    
    private void DrawUI()
    {
       experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _LevelValue.ToString();
    }
}
