using Eloi.IntMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Eloi.IntMapping
{
    public class IntMapMono_Register : MonoBehaviour
    {
        public IntMapRegister m_registerLanguage=new IntMapRegister ();

        public void CheckInstance()
        {
            if (m_registerLanguage == null)
                m_registerLanguage = new IntMapRegister();
        }
        public void GetDefaultEnglish(in int integerValue, out bool found, out IntegerMappingLabel description)
        {
            CheckInstance();
            m_registerLanguage.Get(integerValue, IntegerLanguageCode.EN, out found, out description);
        }

        public void Get(in int integerValue, in string languageCodeNN, out bool found, out IntegerMappingLabel description)
        {
            CheckInstance();
            m_registerLanguage.Get(integerValue, languageCodeNN, out found, out description);
        }

        public void Set(IntegerMappingGroup group)
        {
            Set(group.m_mapping);
        }

        public void Set(List<IntegerMappingLabel> listOfMappingInteger)
        {
            foreach (var item in listOfMappingInteger)
            {
                Set(item);
            }
        }

        public void Set(IntegerMappingLabel integerMapping)
        {
            CheckInstance();
            m_registerLanguage.Set(integerMapping);
        }
        public void SetRaw(int integerValue, string label = "", string description = "", string markdownDescription = "", string languageCodeNN = "EN")
        {
            CheckInstance();
            m_registerLanguage.Set(new IntegerMappingLabel(integerValue, languageCodeNN, label, description, markdownDescription));
        }

        public void SetFromTextAsCsvFormat(string text)
        {
            CsvToIntegerMappingUtility.Import(text, ref m_registerLanguage);
        }

        public void GetIntegersInRegister(out List<int> integers)
        {
            CheckInstance();
            m_registerLanguage.GetIntegersInRegister(out integers);
            integers= integers.Distinct().ToList();
        }
    }


    public class CsvToIntegerMappingUtility
    {
        public static void Import(string text, ref IntMapMono_Register register)
        {

            Import(text, ref register.m_registerLanguage);

        }
        public static void Import(string text, ref IntMapRegister register) {
            //INTEGER;NN;LABEL;DESCRIPTION;MARKDOWNDESCRIPTION
            string[] lines = text.Split('\n');
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] columns = line.Split(';');
                int integerValue;
                string languageCodeNN;
                string label;
                string description;
                string markdownDescription;
                if (columns.Length >= 1 && int.TryParse(columns[0], out int value))
                {
                    integerValue = value;
                    languageCodeNN = columns.Length >= 2 ? columns[1] : "EN";
                    label = columns.Length >= 3 ? columns[2] : "";
                    description = columns.Length >= 4 ? columns[3] : "";
                    markdownDescription = columns.Length >= 5 ? columns[4] : "";
                    IntegerMappingLabel map = new IntegerMappingLabel(integerValue, languageCodeNN, label, description, markdownDescription);
                    register.Set(map);
                }
            }

        }
    }
}


