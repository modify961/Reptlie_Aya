using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using Base.Common.Error;

namespace Base.Logic.Basis
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] //对象在每次调用前创建，在调用后回收
    [SerrverErrorAttribute]
    public class Foundation
    {
        protected readonly HttpContext _httpcontext;
        public Foundation()
        {
            _httpcontext = HttpContext.Current;
        }
    }
}
