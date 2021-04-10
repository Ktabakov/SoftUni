using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Contracts
{
    public interface IEngineer :ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void Add(IRepair repair);
    }
}
