using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace fourth_exersize.Controllers
{
	public class CandidateController : Controller
	{
		private readonly ILogger<CandidateController> _logger;
		private readonly IConfiguration _configuration;

		public CandidateController(ILogger<CandidateController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		// GET: CandidateSearch
		public IActionResult CandidateSearch()
		{
			return View();
		}

		[HttpGet]
		[HttpPost]
		public IActionResult CandidateList(String username, String location, String experienceLevel)
		{
			using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
			ApplicantModel applicantModel = new ApplicantModel(connection);
			var matchedApplicants = applicantModel.getMatches(username, location, experienceLevel);
			connection.Close();
			return View(matchedApplicants);
		}

	}
}
