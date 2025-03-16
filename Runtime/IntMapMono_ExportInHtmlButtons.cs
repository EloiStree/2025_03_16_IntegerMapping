using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.IntMapping
{
    public class IntMapMono_ExportInHtmlButtons : MonoBehaviour
    {

        public IntMapMono_Register m_register;

        [TextArea(0,10)]
        public string m_template = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Button Grid</title>
    <style>
         body {
            background-color: black;
            color: rgb(0, 255, 0);
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            font-family: Arial, sans-serif;
        }
        .GRID {
            display: grid;
            grid-template-columns: repeat(5, 1fr);
            grid-template-rows: repeat(5, 1fr);
            gap: 10px;
            width: 80%;
            height: 80%;
        } /* Missing closing brace added here */
        button {
            background-color: black;
            color: rgb(0, 255, 0);
            font-size: 20px;
            border: 1px solid rgb(0, 255, 0);
            cursor: pointer;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: background-color 0.3s ease;
        }
        button:hover {
            background-color: rgb(31, 31, 31);
        }
    </style>
</head>
<body>

       ##BUTTONS##
      
    <script>
        function PushInteger(valueInteger) {
            console.log(""Button "" + valueInteger + "" clicked"");
        }
    </script>
</body>
</html>
";
        [TextArea(0,5)]
        public string m_htmlPage = @"";
        public string m_buttonTemplate = @"<button class=""GRIDBUTTON"" onclick=""PushInteger({0})"" title=""{2}"">{1} ({0})</button>";
        public string m_lineButtonTemplate = @"<div class=""LINEBUTTONDIV""><button onclick=""PushInteger({0})"" title=""{2}"">{1} ({0})</button><span>{2}</span></div>";
        public string m_languageNN = "EN";
        public UnityEvent<string> m_onHtmlPageBuild;

        [ContextMenu("Export")]
        public void Export()
        {
            StringBuilder sb = new StringBuilder();

            m_register.GetIntegersInRegister(out List<int> integers);

            sb.AppendLine("<div id=\"GRID\">");
            foreach (var item in integers)
            {
                m_register.Get(item, m_languageNN, out bool found, out IntegerMappingLabel label);
                sb.AppendLine(string.Format(m_buttonTemplate, item, label.m_label, label.m_description));
            }
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"LINEARRAY\">");
            foreach (var item in integers)
            {
                m_register.Get(item, m_languageNN, out bool found, out IntegerMappingLabel label);
                sb.AppendLine(string.Format(m_lineButtonTemplate, item, label.m_label, label.m_description));
            }
            sb.AppendLine("</div>");


            m_htmlPage = m_template.Replace("##BUTTONS##", sb.ToString() );
            m_onHtmlPageBuild.Invoke(m_htmlPage);

        }
    }
}

