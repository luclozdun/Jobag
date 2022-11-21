namespace Jobag.src.Ability.Application.DTOs
{
    public class SkillRequest
    {
        public string Name { get; }
        public string Description { get; }

        public SkillRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}