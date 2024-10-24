using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Enemy_Hud : MonoBehaviour
{
    public TMP_Text nameText;
    public Slider hpSlider;

    public void SetHUD(Enemy_unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.unitMaxhp;
        hpSlider.value = unit.unitCurrenthp;

    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }
}
