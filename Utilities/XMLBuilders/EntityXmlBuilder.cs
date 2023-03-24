using MA_GameFramework.Objects.Entities;
using MA_GameFramework.Utilities.XmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.XMLBuilders
{

    /// <summary>
    /// XmlBuilder for the Entity-type.
    /// </summary>
    /// <typeparam name="TBase">Type of object, where the serialized objects, are nesten within.</typeparam>
    public static class EntityXmlBuilder<TBase> where TBase : Entity
    {

        #region Builders
        /// <summary>
        /// Function that builds object from an .XML file, defined by the path.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize. The element name must match the type.</typeparam>
        /// <param name="path">Path to the .xml-file.</param>
        /// <returns>IEnumerable of T.</returns>
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
