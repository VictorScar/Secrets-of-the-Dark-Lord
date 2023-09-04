using SODL.Character;
using SODL.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SODL.DiceRoll
{
    public class DiceRollController : MonoBehaviour
    {
        int diceValue = 0;
        [SerializeField] DiceRolling dice;

        public event Action<int> diceResultObtained;

        private void Start()
        {
            dice.onResultObtained += GetDiceValue;
            Game.Instance.DiceRollManager.InitScene(this);
        }

        public void GetDiceValue(int value)
        {
            diceValue = value;
            //diceResultObtained?.Invoke(diceValue);
            Debug.Log($"Значение кубика: {diceValue}");
        }

        public void ReturnResult()
        {
            diceResultObtained?.Invoke(diceValue);
        }

        private void OnDestroy()
        {
            dice.onResultObtained -= GetDiceValue;
        }
    }
}