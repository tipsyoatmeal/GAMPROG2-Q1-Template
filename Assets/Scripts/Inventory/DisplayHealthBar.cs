using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DisplayHealthBar : MonoBehaviour
{
    public TextMeshProUGUI textHP, textMP;
    public Image fillHP, fillMP;

    private void UpdateBar()
    {
        Player player = InventoryManager.Instance.player;
        float currentHealth = player.GetAttributeValue(AttributeType.HP);
        float currentMana = player.GetAttributeValue(AttributeType.MP);
        fillHP.fillAmount = currentHealth / player.maxHP;
        textHP.text = ($"HP {currentHealth} / {player.maxHP}");
        fillMP.fillAmount = currentMana / player.maxMP;
        textMP.text = ($"MP {currentMana} / {player.maxMP}");
    }

    private void Update()
    {
        UpdateBar();
    }
}
