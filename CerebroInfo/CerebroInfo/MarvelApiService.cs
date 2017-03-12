using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Text;
using CerebroInfo.Dto;

namespace CerebroInfo
{
    internal static class MarvelApiService
    {
        private const string _publicKey = "ab800b2256beb774eb40caf130abced9";
        private const string _privateKey = "b0142888ef08ffe742797c5b9b7d87355af61576";
        private const string _domain = "http://gateway.marvel.com";

        private static string ObtainHashToMd5(string ts)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);


            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(ts + _privateKey + _publicKey, BinaryStringEncoding.Utf8);

            var hashed = alg.HashData(buff);

            var result = CryptographicBuffer.EncodeToHexString(hashed);

            return result;
        }
        private static string GetFormatedUrl(string url)
        {
            string result = string.Empty;
            var ts = GetTimestamp();
            result = $"{_domain}{url}&apikey={_publicKey}&ts={ts}&hash={ObtainHashToMd5(ts)}";

            return result;
        }
        internal  async static Task<RootObject> SearchMarvelCharacters(int limit = 100, int offset = 0)
        {
            string url = GetFormatedUrl($"/v1/public/characters?limit={limit}?offset={offset}");
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            var serializer  = new DataContractJsonSerializer(typeof(RootObject));
            var result = await response.Content.ReadAsStringAsync();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
        private static string GetTimestamp()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = DateTime.UtcNow - origin;

            return Math.Floor(diff.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

    }
}