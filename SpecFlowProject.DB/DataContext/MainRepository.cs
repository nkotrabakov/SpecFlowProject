using SpecFlowProject.Common.Configurations;
using SpecFlowProject.DB.DBContext;
using SpecFlowProject.DB.Models;
using SpecFlowProject.DB.Utils;

namespace SpecFlowProject.DB.DataContext
{
    public class MainRepository
    {
        public BaseDBClient<SuTContext, UserEntity> Repository { get; }

        public MainRepository()
        {
            var connection = ConfigurationProvider.GetValue[ConfigurationLabels.DBConnectionString];
            Repository = new BaseDBClient<SuTContext, UserEntity>(connection);
        }
    }
}
