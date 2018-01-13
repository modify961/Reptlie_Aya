using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using Base.Entity;
using System.ServiceModel.Dispatcher;

namespace Base.Common.Error
{
    public class SerrverErrorAttribute : Attribute, IServiceBehavior
    {
        private DispatcherError _dispatchererror;
        public SerrverErrorAttribute()
        {
            _dispatchererror = new DispatcherError(error => new ErrorMessage()
            {
                id = Guid.NewGuid().ToString(),
                message = error.Message,
                stackTrace = error.StackTrace
            }, delegate(Exception ex)
            {
                //预留调用日志接口
                return false;
            });
        }
        #region IServiceBehavior 成员
        /// <summary>
        /// /
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(this._dispatchererror);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }

        #endregion
    }
}
