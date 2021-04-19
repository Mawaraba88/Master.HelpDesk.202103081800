
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Interfaces
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(IConfiguration configuration);
        

        
    }
}
