using Newtonsoft.Json.Serialization;
using System;

namespace WeBStore
{
    internal class CamelCasePropertyNameContractResolver : IContractResolver
    {
        public JsonContract ResolveContract(Type type)
        {
            throw new NotImplementedException();
        }
    }
}