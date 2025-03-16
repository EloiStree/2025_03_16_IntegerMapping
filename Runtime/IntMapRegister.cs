using System;
using System.Collections.Generic;
namespace Eloi.IntMapping
{
    public class IntMapRegister
    {
        string m_languageCode = IntegerLanguageCode.EN;
        Dictionary<int, IntegerMappingLabel> m_mapping=new Dictionary<int, IntegerMappingLabel>();


        public void GetLanguageCode(out string languageCode)
        {
            languageCode = m_languageCode;
        }
        public string GetLanguageCode()
        {
            return m_languageCode;
        }

        public IntMapRegister() {
            m_languageCode = "  "; 
        }
        public IntMapRegister(string languageCode)
        {
            m_languageCode = languageCode;
        }

        public void Get(in int integerValue, string eN, out bool found, out IntegerMappingLabel description)
        {
            if (m_mapping == null)
                m_mapping = new Dictionary<int, IntegerMappingLabel>();

            found = false;
            if (m_mapping.ContainsKey(integerValue))
            {
                description = m_mapping[integerValue];
                found = true;
                return;
            }
            else
            {
                description = null;
                found = false;
                return;
            }
        }

        public void Set(in IntegerMappingLabel integerMapping)
        {
            if (m_mapping == null)
                m_mapping = new Dictionary<int, IntegerMappingLabel>();
            if (m_mapping.ContainsKey(integerMapping.m_integerValue))
            {
                m_mapping[integerMapping.m_integerValue] = integerMapping;
            }
            else
            {
                m_mapping.Add(integerMapping.m_integerValue, integerMapping);
            }
        }

        public void Set(in int integerValue, in string label = "", in string description = "", in string markdownDescription = "", string languageCodeNN="  ")
        {
            Set(new IntegerMappingLabel(integerValue, languageCodeNN, label, description, markdownDescription));
        }

        public void GetIntegersInRegister(out List<int> ints)
        {
            if (m_mapping == null)
                m_mapping = new Dictionary<int, IntegerMappingLabel>();
            ints = new List<int>();
            foreach (var item in m_mapping.Values)
            {
                if (item !=null)
                    ints.Add(item.m_integerValue);
            }
        }

    }
}

