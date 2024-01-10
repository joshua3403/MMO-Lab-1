using System.Collections.Generic;
using UnityEngine;


namespace Data
{
    #region TestData
    [SerializeField]
    public class TestData
    {
        public int Level;
        public int Exp;
        public List<int> Skills;
        public float Speed;
        public string Name;
    }

    [SerializeField]
    public class TestDataLoader : ILoader<int, TestData>
    {
        public List<TestData> tests = new();

        public Dictionary<int, TestData> MakeDict()
        {
            Dictionary<int, TestData> dict = new();
            foreach (var testData in tests)
                dict.Add(testData.Level, testData);

            return dict;
        }
    }

    #endregion
}