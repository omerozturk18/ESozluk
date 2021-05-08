using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
                
        }
    }
}
