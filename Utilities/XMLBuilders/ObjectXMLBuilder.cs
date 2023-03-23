using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MA_GameFramework.Utilities.XMLBuilders
{
    public static class ObjectXMLBuilder
    {

        /// <summary>
        /// Dictionary to hold serializers, such that they can be resued
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/12736882/can-i-specify-xmlroot-via-code-instead-of-attributes"/>
        private static Dictionary<string, XmlSerializer> _serializers = new Dictionary<string, XmlSerializer>();

        /// <summary>
        /// Function that builds objects, from a given .XML file,
        /// where the objects are stored in a parentElement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parentElement"></param>
        /// <returns></returns>
        public static IEnumerable<T> BuildObjects<T>(string path, string parentElement) where T : new()
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            XmlNode? parentNode = xml.DocumentElement.SelectSingleNode(parentElement);

            return BuildObjects<T>(parentNode);
        }

        public static IEnumerable<T> BuildObjects<T>(XmlNode? node) where T : new()
        {

            List<T> collection = new List<T>();

            /**
             * Guard Clause to prevent execution, if the node is null.
             */
            if (node == null)
                return collection;

            foreach(XmlNode cNode in node.SelectNodes(typeof(T).Name))
            {
                collection.Add(BuildObject<T>(cNode));
            }

            return collection;

        }

        private static T BuildObject<T>(XmlNode node) where T : new()
        {

            if (!_serializers.ContainsKey(typeof(T).Name))
                _serializers.Add(typeof(T).Name, new XmlSerializer(typeof(T), new XmlRootAttribute(typeof(T).Name)));

            XmlSerializer seralizer = _serializers[typeof(T).Name];
           
            T obj;

            using (XmlNodeReader reader = new XmlNodeReader(node))
            {
                obj = (T)seralizer.Deserialize(reader);
            }

            return obj;
        
        }

    }
}
