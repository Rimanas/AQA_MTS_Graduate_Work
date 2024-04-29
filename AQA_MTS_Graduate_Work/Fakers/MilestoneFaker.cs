using AQA_MTS_Graduate_Work.Models;
using Bogus;

namespace AQA_MTS_Graduate_Work.Fakers
{
    public class MilestoneFaker : Faker<Milestone>
    {
        public MilestoneFaker()
        {
            RuleFor(b => b.Name, f => f.Random.AlphaNumeric(5));
            RuleFor(b => b.Description, f => f.Random.Words(1));
            //RuleFor(b => b.Refs, f => f.Random.AlphaNumeric(5));
        }
    }
}