using AQA_MTS_Graduate_Work.Models;
using Bogus;

namespace AQA_MTS_Graduate_Work.Fakers;
    internal class SectionFaker : Faker<Section>
{
    public SectionFaker()
    {
        RuleFor(b => b.Name, f => f.Random.AlphaNumeric(20));
        RuleFor(b => b.Description, f => f.Random.Words(10));
    }
}
