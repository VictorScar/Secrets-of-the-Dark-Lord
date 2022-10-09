namespace SODL.Utils
{
    [System.Serializable]
    public struct ObjectWithChance<T>
    {
        //Структура данных ввиде двух связанных параметров: объект value
        //и значения вероятности его выпадение chance. Структура предназначена для использования в качестве
        //входного параметра для функции RandomWithChance
        public T value;
        public float chance;

    }
}