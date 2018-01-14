using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web.Routing;
using System.ServiceModel.Activation;
using System.Reflection;

namespace Base.Common
{
    public class RoutesHelp
    {
        RouteCollection _routelist = null;
        /// <summary>
        /// 获取xml内注册的类库名称为其增加路由注册
        /// </summary>
        /// <param name="xmlPath"></param>
        public RoutesHelp(string xmlPath)
        {
            if (xmlPath.IndexOf(".xml") != -1)
            {
                XElement xElement = XElement.Load(xmlPath);
                var elements = from q in xElement.Elements("service") select q;
                _routelist = RouteTable.Routes;
                foreach (var item in elements)
                {
                    registerRoutes(item.Attribute("className").Value);
                }
            }
        }
        /// <summary>
        /// 获取类库下的所有的类名，并为他们增加映射
        /// </summary>
        /// <param name="className"></param>
        private void registerRoutes(string className)
        {

            WebServiceHostFactory webServiceHostFactory = new WebServiceHostFactory();
            try
            {
                var types = Assembly.Load(className).GetTypes();
                foreach (var type in types)
                {
                    AddRoute(webServiceHostFactory, type);

                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// 为route增加借口类库的映射
        /// </summary>
        /// <param name="webServiceHostFactory"></param>
        /// <param name="type"></param>
        private void AddRoute(WebServiceHostFactory webServiceHostFactory, Type type)
        {
            if (type.Name.Contains("Service"))
            {
                Route route = new ServiceRoute(type.Name, webServiceHostFactory, type);
                _routelist.Add(route);
            }
        }
    }
}
