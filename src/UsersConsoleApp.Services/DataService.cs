using System;
using System.Collections.Generic;
using System.Linq;
using UsersConsoleApp.Interfaces;

namespace UsersConsoleApp.Services
{
    public class DataService : IDataService
    {
        private readonly IApiService _apiService;
        private readonly IValidationService _validationService;
        private readonly IMappingService _mappingService;

        public DataService(IApiService apiService,
            IValidationService validationService,
            IMappingService mappingService)
        {
            _apiService = apiService;
            _validationService = validationService;
            _mappingService = mappingService;
        }

        public IEnumerable<T> GetData<T>(string apiEndpoint)
        {
            try
            {
                var sourceData = _apiService.GetData(apiEndpoint);

                if (!string.IsNullOrEmpty(sourceData) && _validationService.IsJsonData(sourceData))
                {
                    return _mappingService.ValidateAndMappingJsonData<T>(sourceData);
                }

                return Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
