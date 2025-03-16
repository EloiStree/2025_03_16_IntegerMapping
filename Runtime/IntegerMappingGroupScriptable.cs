using UnityEngine;





namespace Eloi.IntMapping
{
    [CreateAssetMenu(fileName = "IntegerMappingGroup", menuName = "ScriptableObjects/Integer Mapping Label Group", order = 1)]

    /// <summary>
    /// Scriptable object that contains a list of integer mappings.
    /// <\summary>
    public class IntegerMappingGroupScriptable : ScriptableObject
    {
        public IntegerMappingGroup m_data;
    }
}
