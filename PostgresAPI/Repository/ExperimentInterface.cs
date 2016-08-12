using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgresAPI.Models;

namespace PostgresAPI.Repository
{
    public interface ExperimentInterface
    {
        IEnumerable<Experiment> GetAll();
        Experiment Get(string Ex_ID);
        Experiment Add(Experiment item);
        void Remove(string Ex_rID);
        bool Update(Experiment item);
    }
}
