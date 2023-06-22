// See https://aka.ms/new-console-template for more information
using TreeStructureRoads.Lines;


Console.WriteLine("The Cities are connected by Raods ");

String fileInput = "//users//syedqadri/Documents/Dev/TreeStructureRoads/InputData001.txt";
List<Line> lines = FileContextReader.ReadFile(fileInput);
Console.WriteLine($"There are about {lines[1]} connected cities");
lines.RemoveAt(0);
lines.RemoveAt(1);
Console.WriteLine($"Load All Cities");
List<City> loadedCities = CityResolver.ConnectAllCities(lines);

class CityResolver 
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
      else if(cities.Any(p=>p.CityValue == fromData) )
      {
         var selectedCity = cities.First(p=>p.CityValue == fromData);
        // check conneted cities exist
        if(selectedCity.ConnectedCities != null)
        {
           if(!selectedCity.ConnectedCities.Any(p=>p.CityValue == toData))
           {
              var conCity = new City();
              conCity.CityValue = toData;
              selectedCity.ConnectedCities.Add(conCity);

           }
           else 
           {  
              Console.WriteLine($"The connected city {fromData} to {toData} already exist ");
           }

        }
      }

      else if(cities.Any(p=>p.CityValue == toData) )
      {
         var selectedCityOne = cities.First(p=>p.CityValue == toData);
        // check conneted cities exist
        if(selectedCityOne.ConnectedCities != null)
        {
           if(!selectedCityOne.ConnectedCities.Any(p=>p.CityValue == fromData))
           {
              var conCity = new City();
              conCity.CityValue = fromData;
              selectedCityOne.ConnectedCities.Add(conCity);

           }
           else 
           {  
              Console.WriteLine($"CantThe connected city {toData} to {fromData} already exist ");
           }

        }
       }
      }
    
    return cities;

  }
 }


