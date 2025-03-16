using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;





namespace Eloi.IntMapping
{

    /// <summary>
    /// Represents a mapping between an integer value and its associated label and descriptions.
    /// This is used in the game to define actions and provide documentation.
    /// </summary>
    [System.Serializable]
    public class IntegerMappingLabel
    {
        /// <summary>
        /// The label associated with the integer value, typically used for button labels and references in the game.
        /// </summary>
        [Tooltip("The label for the integer value used for buttons in the game and reference")]
        public string m_label;

        /// <summary>
        /// The integer value that represents a specific action in the game.
        /// </summary>
        [Tooltip("The integer value representing an action in the game")]
    public int m_integerValue;

    /// <summary>
    /// Code of the Langauge a string of 2 char, if null or empty it will be set to "  ".
    /// <\summary>
    [Tooltip("The language code, a string of 2 characters, if null or empty it will be set to \"  \"")]
    public string m_languageCode = "  ";


    /// <summary>
    /// A brief description explaining the meaning of the integer value. It has a minimum size constraint.
    /// </summary>
    [Tooltip("The description of what the integer represents, with a minimum size constraint")]
    public string m_description;

    /// <summary>
    /// A markdown-formatted description allowing more detailed and formatted documentation.
    /// Supports a flexible size range.
    /// </summary>
    [Tooltip("The markdown description for detailed documentation with flexible size")]
    [TextArea(0, 5)]
    public string m_markdownDescription;

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerMappingLabel"/> class.
    /// </summary>
    /// <param name="integerValue">The integer value representing an action in the game.</param>
    /// <param name="label">The label associated with the integer value.</param>
    /// <param name="description">A brief description of the integer value.</param>
    /// <param name="markdownDescription">A markdown-formatted description for detailed documentation.</param>
    public IntegerMappingLabel(int integerValue,string languageCodeNN,string label = "", string description = "", string markdownDescription = "")
    {
        m_integerValue = integerValue;
        SetLanguage(languageCodeNN);
        m_label = label.Trim();
        m_description = description.Trim();
        m_markdownDescription = markdownDescription.Trim();
    }

        public IntegerMappingLabel():this(0)
    {
    }
    public IntegerMappingLabel(int integerValue): this(integerValue, "", "", "")
    {}



        public string LanguageCode { get {
                return GetLanguageCode();
            } 
            set => SetLanguage(value); }
        public void GetLanguageCode(out string languageCode)
        {
            CheckFormatLanguageCode();
            languageCode = m_languageCode;
        }
        public string GetLanguageCode()
        {
            GetLanguageCode(out string languageCode);
            return languageCode;
        }
        private  void CheckFormatLanguageCode()
        {
            if (m_languageCode == null)
                m_languageCode = "  ";
            if (m_languageCode.Length == 1)
                m_languageCode = " " + m_languageCode;
            if (m_languageCode.Length >= 2)
                m_languageCode = m_languageCode.Substring(0, 2);
            m_languageCode = m_languageCode.ToUpper();
        }

        public  void SetLanguage(string languageCodeNN)
        {
            if (languageCodeNN == null)
                languageCodeNN = "  ";
            if (languageCodeNN.Length == 1)
                languageCodeNN = " " + languageCodeNN;
            if (languageCodeNN.Length >= 2)
                languageCodeNN = languageCodeNN.Substring(0, 2);
            languageCodeNN = languageCodeNN.ToUpper();
            m_languageCode = languageCodeNN;
        }

        public void SetIntegerValue(int integerValue)
        {
            m_integerValue = integerValue;
        }
        public void SetLabel(string label)
        {
            m_label = label;
        }
        public void SetDescription(string description)
        {
            m_description = description;
        }
        public void SetMarkdownDescription(string markdownDescription)
        {
            m_markdownDescription = markdownDescription;
        }

        /// <summary>
        /// Gets or sets the integer value representing an action.
        /// </summary>
        public int Integer { get => m_integerValue; set => m_integerValue = value; }

    /// <summary>
    /// Retrieves the integer value.
    /// </summary>
    /// <returns>The integer value.</returns>
    public int GetIntegerValue() => m_integerValue;

    /// <summary>
    /// Retrieves the integer value via an output parameter.
    /// </summary>
    /// <param name="integerValue">Outputs the integer value.</param>
    public void GetIntegerValue(out int integerValue)
    {
        integerValue = m_integerValue;
    }

    /// <summary>
    /// Gets or sets the label associated with the integer value.
    /// </summary>
    public string Label { get => m_label; set => m_label = value; }

    /// <summary>
    /// Retrieves the label.
    /// </summary>
    /// <returns>The label associated with the integer value.</returns>
    public string GetLabel() { GetLabel(out string label); return label; }

    /// <summary>
    /// Retrieves the label via an output parameter.
    /// </summary>
    /// <param name="label">Outputs the label, or the integer value as a string if the label is empty.</param>
    public void GetLabel(out string label)
    {
        label = string.IsNullOrWhiteSpace(m_label) ? m_integerValue.ToString() : m_label;
    }

    /// <summary>
    /// Gets or sets the description of the integer value.
    /// </summary>
    public string Description { get => m_description; set => m_description = value; }

    /// <summary>
    /// Retrieves the description of the integer value.
    /// </summary>
    /// <returns>The description.</returns>
    public string GetDescription() => m_description;

    /// <summary>
    /// Retrieves the description via an output parameter.
    /// </summary>
    /// <param name="description">Outputs the description.</param>
    public void GetDescription(out string description)
    {
        description = m_description;
    }

    /// <summary>
    /// Gets or sets the markdown-formatted description.
    /// </summary>
    public string Markdown { get => m_markdownDescription; set => m_markdownDescription = value; }

    /// <summary>
    /// Retrieves the markdown-formatted description.
    /// </summary>
    /// <returns>The markdown-formatted description.</returns>
    public string GetMarkdownDescription() => m_markdownDescription;

    /// <summary>
    /// Retrieves the markdown-formatted description via an output parameter.
    /// </summary>
    /// <param name="markdownDescription">Outputs the markdown description.</param>
    public void GetMarkdownDescription(out string markdownDescription)
    {
        markdownDescription = m_markdownDescription;
    }
}
}
