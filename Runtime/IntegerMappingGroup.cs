using System.Collections.Generic;
using UnityEngine;





namespace Eloi.IntMapping
{
    /// <summary>
    /// Represents a group of integer mappings.
    /// </summary>
    [System.Serializable]
    public class IntegerMappingGroup
    {
        public List<IntegerMappingLabel> m_mapping = new List<IntegerMappingLabel>();
    }
}
