namespace LibraryLab10 {
	public class Shipyard : Factory {
		private uint _builtShips;

		public uint BuiltShips {
			get => _builtShips;
			private set => _builtShips = value;
		}

		public Shipyard(string orgName, string director, int budget, uint engeneersCount, uint builtShips) :
			base(orgName, director, budget, engeneersCount) {
			BuiltShips = builtShips;
		}

		public Shipyard() { }

		public override void RandomInit() {
			base.RandomInit();
			var rand = new Random();
			BuiltShips = (uint)rand.Next(100, 500);
		}

		public override void Show() {
			base.Show();
			Console.WriteLine($"Количество построеных судн: {BuiltShips}");
		}

		public override bool Equals(object obj) {
			if (obj is not Shipyard)
				return false;
			var sh = (Shipyard)obj;
			return OrgName == sh.OrgName && Director == sh.Director && Budget == sh.Budget &&
				   BuiltShips == sh.BuiltShips;
		}
	}
}
