using MySqlConnector;
using System.Text;

namespace fourth_exersize.Models
{
	public class ApplicantModel
	{
		public readonly MySqlConnection _connection;
		public ApplicantModel(MySqlConnection connection)
		{
			_connection = connection;
		}
		public List<Applicant> getMatches(String username, String location, String experienceLevel)
		{
			var matchedApplicants = new List<Applicant>();
			using (_connection)
			{
				_connection.Open();

				StringBuilder queryBuilder = new StringBuilder("SELECT * FROM users RIGHT JOIN applicants ON users.User_ID=applicants.User_ID WHERE 1=1");

				if (!string.IsNullOrEmpty(username))
				{
					queryBuilder.Append(" AND Name LIKE @Username");
				}

				if (!string.IsNullOrEmpty(location))
				{
					queryBuilder.Append(" AND Location LIKE @Location");
				}

				if (!string.IsNullOrEmpty(experienceLevel))
				{
					queryBuilder.Append(" AND Experience LIKE @ExperienceLevel");
				}

				using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), _connection))
				{

					if (!string.IsNullOrEmpty(username))
					{
						cmd.Parameters.AddWithValue("@Username", "%" + username + "%");
					}

					if (!string.IsNullOrEmpty(location))
					{
						cmd.Parameters.AddWithValue("@Location", "%" + location + "%");
					}

					if (!string.IsNullOrEmpty(experienceLevel))
					{
						cmd.Parameters.AddWithValue("@ExperienceLevel", "%" + experienceLevel + "%");
					}

					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							matchedApplicants.Add(new Applicant(
								Convert.ToInt32(reader["User_ID"]),
								Convert.ToString(reader["Name"]),
								Convert.ToString(reader["Email"]),
								Convert.ToString(reader["Password"]),
								Convert.ToString(reader["Bio"]),
								Convert.ToString(reader["Experience"]),
								Convert.ToString(reader["Location"])
							));
						}
					}
				}
			}

			return matchedApplicants;
		}

	}
}
