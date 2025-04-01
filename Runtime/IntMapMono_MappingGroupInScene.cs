using UnityEngine;





namespace Eloi.IntMapping
{
    public class IntMapMono_MappingGroupInScene : MonoBehaviour
    {
        public IntMapMono_Register m_register;
        public bool m_importOnAwake = true;

        public IntMapMono_MappingGroupManual[] m_foundGroup = new IntMapMono_MappingGroupManual[] { };
        private void Awake()
        {
            if (m_importOnAwake)
                Import();
        }
        [ContextMenu("Import")]
        public void Import()
        {

            foreach (var item in m_foundGroup)
            {
                if (item == null)
                    continue;
                m_register.Set(item.m_group);
            }
        }
        [ContextMenu("Get Mapping from current scene")]
        public void GetMappingInCurrentScene()
        {
            m_foundGroup = FindObjectsByType<IntMapMono_MappingGroupManual>(FindObjectsSortMode.None);

            Import();
        }
    }
}
