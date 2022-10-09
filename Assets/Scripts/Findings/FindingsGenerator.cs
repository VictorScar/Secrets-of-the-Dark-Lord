using SODL.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Finding
{
    public class FindingsGenerator : MonoBehaviour
    {
        [SerializeField, OneLine] List<FindingInfo> findingsPack;
        public FindingInfo GenerateFinding()
        {
            int findingPackCount = findingsPack.Count;
            if (findingPackCount == 0)
            {
                return null;
            }

            int index = Random.Range(0, findingPackCount);
            FindingInfo finding = findingsPack[index];
            findingsPack.RemoveAt(index);
            return finding;
        }

#if UNITY_EDITOR
        [NaughtyAttributes.Button]
        void CleanNulls()
        {
            for (int i = findingsPack.Count - 1; i >= 0; i--)
            {
                if (findingsPack[i].Item == null)
                {
                    findingsPack.RemoveAt(i);
                }
            }
        }
#endif
    }
}