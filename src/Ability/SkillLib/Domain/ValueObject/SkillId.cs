using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Ability.SkillLib.Domain.ValueObject
{
    public class SkillId
    {
        public int Id { get; private set; }

        public SkillId(int id)
        {
            Id = id;
        }

        public static implicit operator int(SkillId skillId)
        {
            return skillId.Id;
        }

        public static SkillId Create(int id)
        {
            return new SkillId(id);
        }
    }
}