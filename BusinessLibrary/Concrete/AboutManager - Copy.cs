using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class SkillManager:ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetAll()
        {
            return _skillDal.GetAll();
        }
        public void AddSkill(Skill skill)
        {
            _skillDal.Add(skill);
        }
        public void DeleteSkill(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            _skillDal.Update(skill);
        }
        public List<Skill> ListSkill(int id)
        {
           return _skillDal.List(e=>e.WriterId == id);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(c => c.WriterId == id);
        }
    }
}
