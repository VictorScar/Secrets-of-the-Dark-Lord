using SODL.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRollController : MonoBehaviour
{
    int diceValue = 0;
  
    public void GetDiceValue(int value)
    {
        diceValue = value;
    }

    public int InitDiceRollScene(GameCharacter character)
    {
        diceValue = 0;
        SceneManager.LoadScene("DiceScene", LoadSceneMode.Additive);
        return diceValue;
    }
}
