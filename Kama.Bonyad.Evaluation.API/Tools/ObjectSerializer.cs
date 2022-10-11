namespace Kama.Bonyad.Evaluation.API.Tools
{
    public class ObjectSerializer : AppCore.IObjectSerializer
    {
        public T Deserialize<T>(string serializedValue)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serializedValue);

        public string Serialize(object obj) 
            => obj == null ? null : Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        
    }
}