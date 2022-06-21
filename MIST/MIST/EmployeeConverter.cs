using MIST.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MIST
{
    public class EmployeeConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<IEmployee>) || objectType == typeof(IEmployee);
        }
        public override object ReadJson(JsonReader reader,
        Type objectType, object existingValue,
        JsonSerializer serializer)
        {
            object resultObject = null;
            if(objectType == typeof(List<IEmployee>))
            {
                var resultEmployeeList = new List<IEmployee>();
                var jsonArray = JArray.Load(reader);
                if (jsonArray == null)
                    return null;
                else
                {
                    foreach (var item in jsonArray)
                    {
                        var jo = item as JObject;
                        IEmployee instance = serializeIEmployee(jo, serializer);
                        resultEmployeeList.Add(instance);
                    }
                }
                resultObject = resultEmployeeList;
            }
            if (objectType == typeof(IEmployee))
            {
                var jo = JObject.Load(reader);
                resultObject = serializeIEmployee(jo, serializer);
            }
            return resultObject;
        }

        IEmployee serializeIEmployee( JObject jo, JsonSerializer jsonSerializer)
        {
            IEmployee instance = null;
            var temp = jo.Value<String>("Type");
            switch (int.Parse(temp))
            {
                case (int)EmployeeType.PROGRAMMER:
                    instance = new Programmer();
                    break;
                default:
                    instance = new Employee();
                    break;

            }
            jsonSerializer.Populate(jo.CreateReader(), instance);
            return instance;
        }

        public override void WriteJson(JsonWriter writer,
        object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Используйте базовый Serializer");
        }
    }
}
