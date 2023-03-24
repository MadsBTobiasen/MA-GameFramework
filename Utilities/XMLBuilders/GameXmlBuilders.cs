using MA_GameFramework.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using MA_GameFramework.Objects.Items;

namespace MA_GameFramework.Utilities.XmlBuilders
{

    public static class ObjectXmlBuilder<TBase> where TBase : class
    {

        /// <summary>
        /// Dictionary to hold serializers, such that they can be resued
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/12736882/can-i-specify-xmlroot-via-code-instead-of-attributes"/>
        private static Dictionary<string, XmlSerializer> _serializers = new Dictionary<string, XmlSerializer>();

        /// <summary>
        /// Function that builds objects from a .xml-file, where the objects are nested within the Tbase-type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parentElement"></param>
        /// <returns>IEnumerable of objects.</returns>
        public static IEnumerable<T> Build<T>(string path) where T : TBase, new()
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            XmlNode? parentNode = xml.DocumentElement.SelectSingleNode($"{typeof(TBase).Name}s");

            return Build<T>(parentNode);
        }

        /// <summary>
        /// Function that builds objects, from a given .XML file, where the objects are nested within the same type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parentElement"></param>
        /// <returns>IEnumerable of objects.</returns>
        public static IEnumerable<TBase> Build(string path)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            XmlNode? parentNode = xml.DocumentElement.SelectSingleNode($"{typeof(TBase).Name}s");

            return Build<TBase>(parentNode);
        }

        /// <summary>
        /// Function that builds objects, from a given XmlNode.
        /// </summary>
        /// <param name="node">XmlNode with objects.</param>
        /// <returns>IEnumerable of objects.</returns>
        private static IEnumerable<T> Build<T>(XmlNode? node)
        {

            List<T> collection = new List<T>();

            /**
             * Guard Clause to prevent execution, if the node is null.
             */
            if (node == null)
                return collection;

            foreach (XmlNode cNode in node.SelectNodes(typeof(T).Name))
            {
                collection.Add(BuildObject<T>(cNode));
            }

            return collection;

        }

        /// <summary>
        /// Function that parses the XmlNode, deserializing the objects, and returning them.
        /// </summary>
        /// <param name="node">XmlNode.</param>
        /// <returns>Object.</returns>
        private static T BuildObject<T>(XmlNode node)
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
