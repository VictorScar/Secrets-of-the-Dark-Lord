using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
 
    public static T RandomWithChance<T>(ObjectWithChance<T>[] objects)
    //Функция принимает массив структур ObjectWithChance, в которых заданны объекты с неопределенным типом 
    //(задается при вызове функции) и значения веротяностиих выпадения, и возвращает случайный объект того же типа
    //с заданным значением вероятности
    {

        float total = 0;

        foreach (ObjectWithChance<T> elem in objects)
        {
            total += elem.chance;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < objects.Length; i++)
        {
            if (randomPoint < objects[i].chance)
            {
                return objects[i].value;
            }
            else
            {
                randomPoint -= objects[i].chance;
            }


        }
        return objects[objects.Length - 1].value;
    }

}
