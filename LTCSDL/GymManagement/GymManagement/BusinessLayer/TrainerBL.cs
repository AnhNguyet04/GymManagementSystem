using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class TrainerBL
    {
        public List<Trainer> GetAllTrainers()
        {
            return new TrainerDL().GetAllTrainers();
        }
        public List<Trainer> GetAvailableTrainers(DateTime newStartDate, DateTime newEndDate, string newSchedule)
        {
            return new TrainerDL().GetAvailableTrainers(newStartDate, newEndDate, newSchedule);
        }
        public Trainer GetTrainerById(int id)
        {
            return new TrainerDL().GetTrainerById(id);
        }
        public Trainer GetTrainerByName(string name)
        {
            return new TrainerDL().GetTrainerByName(name);
        }
    }
}
