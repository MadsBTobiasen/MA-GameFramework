using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.XmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.XMLBuilders
{

    /// <summary>
    /// XmlBuilder that looks in a given .XML file for a <creatures>-tag, and deserializes it.
    /// </summary>
    /// <typeparam name="TBase">Generic type, derived from Item.</typeparam>
    public static class ItemXmlBuilder<TBase> where TBase : Item
    {

        #region Builders
        /// <summary>
        /// Function that builds the objects of type T, with no predefined parentElement.
        /// ParentElement gets assigned to T's name in plural form.
        /// </summary>
        /// <param name="path">Path to .XML.</param>
        /// <returns>IEnumerable of objects.</returns>
        public static IEnumerable<T> Build<T>(string path) where T : TBase, new()
        {
            return ObjectXmlBuilder<TBase>.Build<T>(path);
        }

        /// <summary>
        /// Function that builds object from an .XML file, defined by the path,
        /// without defining the type for the nested objects.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize. The element name must match the type.</typeparam>
        /// <param name="path">Path to the .xml-file.</param>
        /// <returns>IEnumerable of T.</returns>
        public static IEnumerable<TBase> Build(string path)
        {
            return ObjectXmlBuilder<TBase>.Build(path);
        }
        #endregion

    }

}
