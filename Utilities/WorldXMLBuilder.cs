using MA_GameFramework.Utilities.XMLBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MA_GameFramework.Utilities
{
    public static class WorldXMLBuilder
    {

        /// <summary>
        /// Function that builds the World from the .XML file given in the path.
        /// </summary>
        /// <param name="path">Path to configuration file.</param>
        /// <returns>The World Object.</returns>
        public static World BuildWorld(string path)
        {

            #region Builder Setup.
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            WorldBuilder builder = new WorldBuilder();
            #endregion

            #region Grabbing Configuration Values.
            
            BuildDimensions(xml, builder);
            ItemObjectXMLBuilder.BuildItemObjects(xml?.DocumentElement?.SelectSingleNode("ItemObjects"), builder);

            #endregion

            return builder.Build();
        
        }

        /// <summary>
        /// Function that grabs the Dimensions X and Y from the configuration file, and builds the value.
        /// </summary>
        /// <param name="xml">XmlDocument.</param>
        /// <param name="builder">WorldBuilder.</param>
        /// <exception cref="ArgumentException">Exception thrown if the Builder Error'ed.</exception>
        private static void BuildDimensions(XmlDocument xml, WorldBuilder builder)
        {

            XmlNode? maxXNode = xml?.DocumentElement?.SelectSingleNode("MaxX");
            XmlNode? maxYNode = xml?.DocumentElement?.SelectSingleNode("MaxY");

            if (maxXNode is null || maxYNode is null)
                throw new ArgumentException("<MaxX> and <MaxY> must both be present in the Configuration file.");

            int maxX = 0;
            int maxY = 0;

            try
            {
                maxX = Convert.ToInt32(maxXNode.InnerText);
                maxY = Convert.ToInt32(maxYNode.InnerText);

                if (maxX < 1 | maxY < 1)
                    throw new Exception();

            }
            catch
            {
                throw new ArgumentException("Dimensions cannot be less than 1, or null");
            }

            builder.SetDimensions(maxX, maxY);

        }

    }
}
