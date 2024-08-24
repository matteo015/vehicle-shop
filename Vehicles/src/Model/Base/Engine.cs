namespace VEHICLE_SHOP.Vehicles.src.Model.Base
{
    public class Engine
    {
        private static readonly string[] EngineTypes = { "Elétrico", "Combustão", "Hibrido" };
        private string _engineName = "Default";
        private string _engineType = "Default";
        private int horsePower = default;
        private int torque = default;
        public bool Turbo { get; set; }

        public Engine() { }
        public Engine(string engineName, string engineType, int horsePower, int torque, bool Turbo)
        {
            _engineName = engineName;
            _engineType = engineType;
            this.horsePower = horsePower;
            this.torque = torque;
            this.Turbo = Turbo;
        }

        static private bool IsValidEngineType(string type)
        {
            foreach (string t in EngineTypes)
                if (type.Equals(t)) return true;
            return false;
        }

        public string EngineName
        {
            get { return _engineName; }
            set
            {
                if (!string.Equals(_engineName, "Default")) return;
                if (!string.IsNullOrEmpty(value)) return;
                _engineName = value;
            }
        }

        public string EngineType
        {
            get { return _engineType; }
            set
            {
                if (!string.Equals(_engineName, "Default")) return;
                if (!IsValidEngineType(value)) return;
                _engineType = value;
            }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set
            {
                if (horsePower != default) return;
                horsePower = value;
            }
        }

        public int Torque
        {
            get { return torque; }
            set
            {
                if (torque != default) return;
                torque = value;
            }
        }
    }
}