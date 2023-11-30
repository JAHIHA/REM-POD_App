namespace REM_POD_App.files
{
    public class Model
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Temperature { get; set; }


        //Magnetometer retunere 3 tal
        public double MagnetometerX { get; set; }

        public double MagnetometerY { get; set; }

        public double MagnetometerZ { get; set; }


        public double Distance { get; set; }

        public Model(int id, DateTime timeStamp, double temperature, double magnetometerX, double magnetometerY, double magnetometerZ, double distance)
        {
            Id = id;
            TimeStamp = timeStamp;
            Temperature = temperature;
            MagnetometerX = magnetometerX;
            MagnetometerY = magnetometerY;
            MagnetometerZ = magnetometerZ;
            Distance = distance;
        }

        public Model()
        {
            this.Id = 0;
            this.TimeStamp = DateTime.Now;
            this.Temperature = 0.0;
            this.MagnetometerX = 0.0;
            this.MagnetometerY = 0.0;
            this.MagnetometerZ = 0.0;
            this.Distance = 0.0;

        }

        public override string ToString()
        {
            return $"Id = {Id}, Temperature = {Temperature}, MagnetometerX = {MagnetometerX}, MagnetometerY = {MagnetometerY}, MagnetometerZ = {MagnetometerZ}, Distance = {Distance}";
        }


        public void ValidateTemp()
        {
            if (Temperature <= -10 || Temperature > 30)
            {
                throw new ArgumentException("Temperature must be between -10 and 30");
            }
        }

        public void ValidateDist()
        {
            if (Distance < 3)
            {
                throw new ArgumentException("Distance must not be closer then 3 meters");
            }
        }

    }
}
