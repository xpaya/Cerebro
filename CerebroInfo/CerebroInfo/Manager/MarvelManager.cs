using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerebroInfo.Manager.Dto;

namespace CerebroInfo.Manager
{
    public static class MarvelManager
    {
        public static async Task<CharacterInfoDto> SearchStartWith(string name, int limit = 25, int offset = 0)
        {
            var result = new CharacterInfoDto();
            var data = await MarvelApiService.SearchStartWith(name,limit, offset);
            if (data != null)
            {
                result.IsFinalData = data.data.results.Count != limit;
                result.Characters.AddRange(data.data.results.Select(x => new CharacterDto()
                {
                    Description = x.description,
                    Id = x.id,
                    Name = x.name,
                    Image = x.thumbnail.path + "/portrait_xlarge." + x.thumbnail.extension
                }));
            }
            return result;
        }
        public static async Task<CharacterInfoDto>  GetCharacters(int limit = 25, int offset = 0)
        {
            var result = new CharacterInfoDto();
            var data = await MarvelApiService.SearchMarvelCharacters(limit, offset);
            if (data != null)
            {
                result.IsFinalData = data.data.results.Count != limit;
                result.Characters.AddRange(data.data.results.Select(x=> new CharacterDto()
                {
                   Description = x.description,
                   Id = x.id,
                   Name = x.name,
                   Image = x.thumbnail.path + "/portrait_xlarge." + x.thumbnail.extension
                }));
            }
            return result;
        }
    }
}