namespace LibraryLab10 {
	public class InsuranceCompany : Organisation {
		private uint _insuranceCases; //количество страховых случаев

		public InsuranceCompany(string orgName, string director, int budget, uint insuranceCases) :
			base(orgName, director, budget) {
			InsuranceCases = insuranceCases;
		}

		public InsuranceCompany() { }

		public uint InsuranceCases {
			get => _insuranceCases;
			set => _insuranceCases = value;
		}

		public override void RandomInit() {
			base.RandomInit();
			var rand = new Random();
			InsuranceCases = (uint)rand.Next(9999);
		}

		public override void Show() {
			base.Show();
			Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
		}

		public override bool Equals(object obj) {
			if (obj is not InsuranceCompany)
				return false;
			var ins = (InsuranceCompany)obj;
			return OrgName == ins.OrgName && Director == ins.Director && Budget == ins.Budget &&
				   InsuranceCases == ins.InsuranceCases;
		}
	}
}
