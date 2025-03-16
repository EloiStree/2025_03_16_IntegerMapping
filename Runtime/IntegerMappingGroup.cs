using System.Collections.Generic;





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
