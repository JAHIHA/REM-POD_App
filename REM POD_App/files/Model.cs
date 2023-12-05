namespace REM_POD_App.files
{
    public class Model
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Temperature { get; set; }

        public double Magnetometer { get; set; }


        public double Distance { get; set; }

        private static int nextid{ get; set; }

        public Model(  double temperature, double magnetometer, double distance)
        {
            Id = nextid++;
            TimeStamp = DateTime.Now;
            Temperature = temperature;
            Magnetometer = magnetometer;
            Distance = distance;
        }

        public Model()
        {
           
        }

        public override string ToString()
        {
            return $"Id = {Id}, Temperature = {Temperature}, Magnetometer = {Magnetometer}, Distance = {Distance}";
        }


        public void ValidateTemp()
        {
            if (Temperature <= -10 || Temperature > 30)
            {
                throw new ArgumentOutOfRangeException("Temperature must be between -10 and 30");
            }
        }

        public void ValidateDist()
        {
            if (Distance < 3)
            {
                throw new ArgumentException("Distance must not be closer then 3 meters");
            }
        }

        public void Validate()
        {
            ValidateTemp();
            ValidateDist();
        }

    }
}
