[System.Serializable] 
public struct ObjectWithChance<T>
{
   
    public T value;
    public float chance;
  
}

//Структура данных ввиде двух связанных параметров: Объект неопределенного типа <T> value(задается при создание объекта структуры)
//и значения вероятности его выпадение chance
