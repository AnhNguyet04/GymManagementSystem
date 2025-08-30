using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Trainer
    {
        public int TrainerID {  get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> Classes { get; set; }
        public Trainer()
        {
            Classes = new List<string>();
        }
    }
}
