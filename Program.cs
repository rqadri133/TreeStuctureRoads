// See https://aka.ms/new-console-template for more information
// This is derived from hacker rank skill problem solving practise test please dont cheat nor copy
// the excersice is owned by hacker ranck 
// i am only working on solution to learn new techniques
// The solution is in progress provided solely by Syed Rafiuddin Qadri 
// Please dont cheat for any test submission 

Console.WriteLine("The Cities are connected by Raods ");

String fileInput = "//users//syedqadri/Documents/Dev/TreeStructureRoads/InputData001.txt";
List<Line> lines = FileContextReader.ReadFile(fileInput);
Console.WriteLine($"There are about {lines[1]} connected cities");
lines.RemoveAt(0);
lines.RemoveAt(1);
Console.WriteLine($"Load All Cities");
List<City> loadedCities = CityResolver.ConnectAllCities(lines);


public class CityResolver 
{




public static List<City> ConnectAllCities(List<Line> lines)
{
    List<City> cities = new List<City>();
   List<City> connectedCities = new List<City>();


foreach(Line line in lines)
{

     string[] inputLine =  line.LineContent.Split(" ".ToCharArray());
     int fromData =  Convert.ToInt32(inputLine[0]);
     int toData = Convert.ToInt32(inputLine[1]);
      if(!cities.Any(p=>p.CityValue == fromData) && !cities.Any(p=>p.CityValue == toData ) )
      {
          // means the City Node never connected nor created 
          // create a city from from Data ;
          // crate a cirty from to Data and connect it 
           var city = new City();
           city.CityValue = fromData; 
           cities.Add(city);
           var cityTo = new City();
           cityTo.CityValue = toData;
           // connect this city
           // but you have to add this city also
           cities.Add(cityTo);
           // Remmber this from Data never created so you will instantiate a new connected city list here 
           // Now count road here 1 city to another city 1 road 
           // flip back you need another Road
           connectedCities = new List<City>();
             
           connectedCities.Add(cityTo);
           city.ConnectedCities = connectedCities;
                     
      }
      else if(cities.Any(p=>p.CityValue == fromData) && !cities.Any(p=>p.ConnectedCities.Any(q=>q.CityValue == toData)))
      {
        // i found city and i also making sure that its not connected to 
        // so i will add into connected city 
          var selectedCity = cities.First(j=>j.CityValue == fromData); 
          if(selectedCity.ConnectedCities != null)
          {
              var newCity = new City();
              newCity.CityValue = toData;
              selectedCity.ConnectedCities.Add(newCity);

          }   

      }

    }
    return cities;

}
}








