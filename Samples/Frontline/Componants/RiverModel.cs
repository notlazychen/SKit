using Frontline.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Componants
{
    [ModelBinder(BinderType = typeof(RiverBinder))]
    public class RiverModel
    {
        private Dictionary<string, string> _data;

        public RiverModel()
        {
        }

        public RiverModel(Dictionary<string, string> data)
        {
            _data = data;
        }

        public ICollection<string> Keys { get { return _data.Keys; } }
        public ICollection<string> Values { get { return _data.Values; } }

        public string this[string key]
        {
            get
            {
                _data.TryGetValue(key, out var v);
                return v;
            }
        }
    }

    public class RiverBinder : IModelBinder
    {
        private const string _key = "421w6tW1ivg=";

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var request = bindingContext.HttpContext.Request;
            byte[] data = new byte[(int)request.ContentLength];
            int size = request.Body.Read(data, 0, data.Length);
            string str = DES.Decrypt(data, _key);
            var dic = str.Split("&").Select(x => x.Split("=")).ToDictionary(n => n[0], n => n[1]);
            bindingContext.Result = ModelBindingResult.Success(new RiverModel(dic));

            return Task.CompletedTask;
        }
    }
}
