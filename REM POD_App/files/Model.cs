namespace REM_POD_App.files
{
    public class Model
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Temperature { get; set; }

        public double Magnetometer { get; set; }

        public double Distance { get; set; }

        public Model(int id, DateTime timeStamp, double temperature, double magnetometer, double distance)
        {
            Id = id;
            TimeStamp = timeStamp;
            Temperature = temperature;
            Magnetometer = magnetometer;
            Distance = distance;
        }

        public Model()
        {
            this.Id = 0;
            this.TimeStamp = DateTime.Now;
            this.Temperature = 0.0;
            this.Magnetometer = 0.0;
            this.Distance = 0.0;

        }

        public override string ToString()
        {
            return $"{Id}, {TimeStamp} {Temperature}, {Magnetometer}, {Distance}";
        }
    }
}
