using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQA_MTS_Graduate_Work.Models;
public class MilestoneBuilder
{
    public string ID { get; }
    public string MilestoneName { get; }
    public string Description { get; }

    private MilestoneBuilder(string id, string milestoneName, string description)
    {
        ID = id;
        MilestoneName = milestoneName;
        Description = description;
    }
    public class Builder
    {
        private string ID { get; set; }
        private string MilestoneName { get; set; }
        private string Description { get; set; }
        //Методы для установки значений полей и возвращения Builder для дальнейшего вызова по цепочке
        public Builder SetID(string id)
        {
            ID = id;
            return this;
        }
        public Builder SetMilestoneName(string milestoneName)
        {
            MilestoneName = milestoneName;
            return this;
        }
        public Builder SetDescription(string description)
        {
            Description = description;
            return this;
        }

        //Метод для построения объеккта
        public MilestoneBuilder Build()
        {
            if (string.IsNullOrEmpty(MilestoneName))
                throw new InvalidOperationException("Name must be set");
            return new MilestoneBuilder(ID, MilestoneName, Description);
        }
    }
}
