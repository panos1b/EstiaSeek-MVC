namespace fourth_exersize.Models
{
	public class Applicant
	{
		public int Id { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; }
		public string? Email { get; set; }
		public string? Bio { get; }
		public string? Experience { get; set; }
		public string? Location { get; set; }

		public Applicant(int _id, string _name, string _email, string _password, string _bio, string _experience, string _location)
		{
			Id = _id;
			UserName = _name;
			Email = _email;
			Password = _password;
			Bio = _bio;
			Experience = _experience;
			Location = _location;
		}
	}
}
