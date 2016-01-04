using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matrix.Company.UI.App_Start
{
    public class PersianDateModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelstate = new ModelState { Value = valueResult };
            object actualvalue = null;
            try
            {
                var parts = valueResult.AttemptedValue.Split('/'); //1393/02/02
                if (parts.Length != 3) return null;
                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);
                actualvalue = new DateTime(year, month, day, new PersianCalendar());
            }
            catch (FormatException e)
            {
                modelstate.Errors.Add(e);
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelstate);
            return actualvalue;
        }
    }
}