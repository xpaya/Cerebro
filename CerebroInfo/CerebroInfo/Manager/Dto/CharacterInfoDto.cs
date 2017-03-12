using System.Collections.Generic;

namespace CerebroInfo.Manager.Dto
{
    public class CharacterInfoDto
    {
        public CharacterInfoDto()
        {
            Characters = new List<CharacterDto>();
        }
        public bool IsFinalData { get; set; }
        public List<CharacterDto> Characters { get; set; }
    }
}