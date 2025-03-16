using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.IntMapping
{
    public class IntMapMono_ImportGroupScritable : MonoBehaviour
    {

        public IntMapMono_Register m_register;

        public Eloi.IntMapping.IntegerMappingGroupScriptable[] m_scritable;

        public bool m_importOnAwake = true;
        private void Awake()
        {
            if (m_importOnAwake)
                Import();
        }
        [ContextMenu("Import")]
        public void Import()
        {

            foreach (var item in m_scritable)
            {
                if (item == null)
                    continue;
                m_register.Set(item.m_data);
            }
        }
    }
}

