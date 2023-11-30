namespace REM_POD_App.files
{
    public class Model
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Temperature { get; set; }

        public double Magnetometer { get; set; }

        public double Distance { get; set; }



        public override string ToString()
        {
            return $"{Id}, {TimeStamp} {Temperature}, {Magnetometer}, {Distance}";
        }
    }
}
