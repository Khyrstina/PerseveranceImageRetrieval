namespace RoverImageRetrieval2.Models
{

    public class Rootobject
    {
        public Latest_Photos[] latest_photos { get; set; }
    }
    //These are what the program is retrieving from the API
    //They come with all lowercase naming but they can be renamed with ctrl . "fix naming conventions" 
    public class Latest_Photos
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Rover rover { get; set; }
    }

    public class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }
    }

    public class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }
    }

}
