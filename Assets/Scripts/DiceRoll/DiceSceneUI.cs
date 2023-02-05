using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSceneUI : MonoBehaviour
{
    [SerializeField] TMP_Text descriptionUI;
    [SerializeField] TMP_Text diceValueUI;

    void Start()
    {
        StartCoroutine(ShowDiscriptionCoroutine());
    }


    void Update()
    {

    }

    public void ShowDiceValue(int diceValue)
    {
        StartCoroutine(ShowDiceValueCoroutine(diceValue));
    }

    IEnumerator ShowDiceValueCoroutine(int diceValue)
    {
        diceValueUI.gameObject.SetActive(true);
        diceValueUI.text = $"Выпало: {diceValue}";
        yield return new WaitForSeconds(2);
        diceValueUI.gameObject.SetActive(false);
    }

    IEnumerator ShowDiscriptionCoroutine()
    {
        descriptionUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        descriptionUI.gameObject.SetActive(false);
    }
}
