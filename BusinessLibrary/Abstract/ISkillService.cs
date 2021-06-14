using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface ISkillService
    {
         List<Skill> GetAll();
        void AddSkill(Skill skill);
        void DeleteSkill(Skill skill);
        void UpdateSkill(Skill skill);
         List<Skill> ListSkill(int id);
         Skill GetById(int id);

    }
}
