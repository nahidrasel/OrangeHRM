using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace OrangeHRM.utilities
{
    public class JsonReader
    {
        public string extractData(String tokenName)
        {
            String myJsonString = File.ReadAllText("TestData/TestData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
