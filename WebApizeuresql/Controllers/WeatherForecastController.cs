using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApizeuresql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    //    private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<employee> Get()
        {

           
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                // builder.DataSource = "winddbserverliz.database.windows.net"; 
                // builder.UserID = "Sqldavidadmin";            
                // builder.Password = "Archer!!77";     
                // builder.InitialCatalog = "MobileAppLizDb";      
                var emp=new List<employee>();
               
                string sqlconstr = "Server=tcp:tigersqlliz.database.windows.net,1433;Initial Catalog=tiger;Persist Security Info=False;User ID=sqlizadmin;Password=Archer!!77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlConnection connection = new SqlConnection(sqlconstr))
                {
                      connection.Open();
                    String sql = "SELECT first_name, last_name, email FROM dbo.employee";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var eee = new employee();

                            while (reader.Read())
                            {
                                eee.firstName = reader.GetString(0);
                                eee.lastName = reader.GetString(1);
                                eee.email=reader.GetString(2);
                                emp.Add(eee);
                            }
                        }
                    }
                    return emp;
                }

            }
            catch (SqlException e)
            {
                return null;
            }

        }
    }
}