using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;

namespace Blog.Web
{
    public class ObjectIdModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ObjectId id;
            
            if (!ObjectId.TryParse((string)result.ConvertTo(typeof(string)), out id))
            {
                return ObjectId.Empty;
            }
            return id;
        }
    }
}