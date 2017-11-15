using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace zmanimapi.Views
{
    public class XmlView : IViewable
    {
        private string _xml;
        public XmlView(Dictionary<String, DateTime?> zmanim)
        {
            XmlDocument doc = new XmlDocument();
            //(1) the xml declaration for the top of the documents
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            //create a root element
            XmlElement rootelem = doc.CreateElement(string.Empty, "Response", string.Empty);
            doc.AppendChild(rootelem);
            //create the date element
            XmlElement element1 = doc.CreateElement(string.Empty, "Date", string.Empty);
            XmlText dateText = doc.CreateTextNode(String.Format("{0:MM/dd/yyyy}", zmanim["Alos"].GetValueOrDefault()));
            element1.AppendChild(dateText);
            rootelem.AppendChild(element1);

        //iterate through all the zmanim and add them to the xml
            foreach (KeyValuePair<string, DateTime?> entry in zmanim)
            {
                XmlElement element = doc.CreateElement(string.Empty, entry.Key, string.Empty);
                XmlText text = doc.CreateTextNode(String.Format("{0:h:m:s:tt}", entry.Value));
           element.AppendChild(text);
               rootelem.AppendChild(element);
            }
            //store the doc string in the _xml
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            doc.Save(writer);
            writer.Close();
            _xml = sb.ToString();
        }

        public string getView()
        {
            return _xml;
        }
    }
}
