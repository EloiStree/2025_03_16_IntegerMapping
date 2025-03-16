using UnityEngine;
using UnityEngine.Events;
namespace Eloi.IntMapping
{
    public class IntMapMono_SplitDescriptionEvent : MonoBehaviour {

        public IntMapMono_Register m_register;
        public int m_lastRegisteredInteger;
        public IntegerMappingLabel m_lastFound;
        public string m_languageNN = "EN";

        public UnityEvent<IntegerMappingLabel> m_onFound;
        public UnityEvent m_onNotFound;
        public UnityEvent<string> m_onInteger;
        public UnityEvent<string> m_onLabel;
        public UnityEvent<string> m_onDescription;
        public UnityEvent<string> m_onMarkdownDescription;

        public void PushIn(int integer)
        {
            m_lastRegisteredInteger = integer;
            m_lastFound = null;

            m_register.Get(integer, m_languageNN, out bool found, out IntegerMappingLabel label);
            if (found)
            {
                m_onFound.Invoke(label);
                m_lastFound = label;
                m_onInteger.Invoke(label.m_integerValue.ToString());
                m_onLabel.Invoke(label.m_label);
                m_onDescription.Invoke(label.m_description);
                m_onMarkdownDescription.Invoke(label.m_markdownDescription);
            }
            else
            {
                m_onNotFound.Invoke();
                m_onFound.Invoke(null);
                m_lastFound = null;
                m_onInteger.Invoke("");
                m_onLabel.Invoke("");
                m_onDescription.Invoke("");
                m_onMarkdownDescription.Invoke("");
            }
        }
    }
}

