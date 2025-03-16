using UnityEngine;
namespace Eloi.IntMapping
{
    public class IntMapMono_ImportFromTextAssets : MonoBehaviour
    {

        public IntMapMono_Register m_register;

        public TextAsset[] m_textToImportInCsvFormat;

        public bool m_importOnAwake = true;
        private void Awake()
        {
            if (m_importOnAwake)
                Import();
        }
        [ContextMenu("Import")]
        public void Import()
        {

            foreach (var item in m_textToImportInCsvFormat)
            {
                m_register.SetFromTextAsCsvFormat(item.text);
            }
        }
    }
}

