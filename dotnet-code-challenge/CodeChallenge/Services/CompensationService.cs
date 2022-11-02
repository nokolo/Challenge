using System;
using CodeChallenge.Repositories;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;


        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _logger = logger;
            _compensationRepository = compensationRepository;
            
        }

        public Compensation Create(Compensation compensation)
        {
            if(compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        public Compensation GetById(string id)
        {
            //return (string.IsNullOrEmpty(id)) ? null : _compensationRepository.GetById(id);
            if (!string.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }
 
    }
}
