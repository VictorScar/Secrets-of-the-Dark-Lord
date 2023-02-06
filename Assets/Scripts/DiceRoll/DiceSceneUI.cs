using System.Collections;
using TMPro;
using UnityEngine;

namespace SODL.DiceRoll
{
    public class DiceSceneUI : MonoBehaviour
    {
        [SerializeField] TMP_Text descriptionUI;
        [SerializeField] TMP_Text diceValueUI;

        [SerializeField] DiceRolling dice;

        IEnumerator Start()
        {
            dice.onResultObtained += (diceValue) => StartCoroutine(ShowDiceValueCoroutine(diceValue));

            //Show description
            descriptionUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            descriptionUI.gameObject.SetActive(false);
        }

        IEnumerator ShowDiceValueCoroutine(int diceValue)
        {
            diceValueUI.gameObject.SetActive(true);
            diceValueUI.text = $"Выпало: {diceValue}";
            yield return new WaitForSeconds(2);
            diceValueUI.gameObject.SetActive(false);
        }
    }
}