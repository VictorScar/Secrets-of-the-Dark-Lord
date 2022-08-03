using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    public static int RandomWithChance(int min, int max, int number1, float chance1)
    {

        int[] arrayNumbers = new int[10];
        float countNumber1 = chance1 * 10;
        if (chance1 >= 0 && chance1 < 1)
        {
            
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                
                if (countNumber1 > 0)
                {
                    arrayNumbers[i] = number1;
                    countNumber1--;
                }
                else
                {
                    arrayNumbers[i] = Random.Range(min, max);
                }
                
            }
        }
        else
        {
            throw new System.NotImplementedException("Ќеверный диапазон шанса выпадени€ числа. ¬ведите значение дл€ 'chance' в диапазоне от 0 до 1");
        }
        int randomNumber = arrayNumbers[Random.Range(0, arrayNumbers.Length)];
        return randomNumber;
    }


    public static int RandomWithChance(int min, int max, int number1, float chance1, int number2, float chance2)
    {
        int[] arrayNumbers = new int[10];
        float countNumber1 = chance1 * 10;
        float countNumber2 = chance2 * 10;
        if (chance1 >= 0 && chance1 < 1 && chance2 >= 0 && chance2 < 1 && chance1 + chance2 < 1)
        {

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
              
                if (countNumber1 > 0)
                {
                    arrayNumbers[i] = number1;
                    countNumber1--;
                }

               
                else if (countNumber2 > 0)
                {
                    arrayNumbers[i] = number2;
                    countNumber2--;
                }

                else
                {
                    arrayNumbers[i] = Random.Range(min, max);
                }
            }
        }
        else
        {
            throw new System.NotImplementedException("Ќеверный диапазон шанса выпадени€ числа. ¬ведите значение дл€ 'chance' в диапазоне от 0 до 1");
        }
        int randomNumber = arrayNumbers[Random.Range(0, arrayNumbers.Length)];
        return randomNumber;
    }

    public static int RandomWithChance(int min, int max, int number1, float chance1, int number2, float chance2, int number3, float chance3)
    {
        int[] arrayNumbers = new int[10];
        float countNumber1 = chance1 * 10;
        float countNumber2 = chance2 * 10;
        float countNumber3 = chance3 * 10;
        if (chance1 >= 0 && chance1 < 1 && chance2 >= 0 && chance2 < 1 && chance3 >= 0 && chance3 < 1 && chance1 + chance2 + chance3 < 1)
        {
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                
                if (countNumber1 > 0)
                {
                    arrayNumbers[i] = number1;
                    countNumber1--;
                }

                
                else if (countNumber2 > 0)
                {
                    arrayNumbers[i] = number2;
                    countNumber2--;
                }

                else if (chance1 + chance2 < 1)
                {
                    
                    if (countNumber3 > 0)
                    {
                        arrayNumbers[i] = number3;
                        countNumber3--;
                    }
                }
                else
                {
                    arrayNumbers[i] = Random.Range(min, max);
                }
            }
        }
        else
        {
            throw new System.NotImplementedException("Ќеверный диапазон шанса выпадени€ числа. ¬ведите значение дл€ 'chance' в диапазоне от 0 до 1");
        }
        int randomNumber = arrayNumbers[Random.Range(0, arrayNumbers.Length)];
        return randomNumber;
    }

}
