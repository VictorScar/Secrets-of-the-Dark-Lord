using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingsGenerator : MonoBehaviour
{
    [SerializeField, OneLine] List<Finding> findingsPack;
    public Finding GenerateFinding()
    {
        int findingPackCount = findingsPack.Count;
        if (findingPackCount == 0)
        {
            return null;
        }

        int index = Random.Range(0, findingPackCount);
        Finding finding = findingsPack[index];
        findingsPack.RemoveAt(index);
        return finding;
    }
}
