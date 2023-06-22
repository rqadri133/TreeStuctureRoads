// See https://aka.ms/new-console-template for more information
using TreeStructureRoads.Lines;


Console.WriteLine("The Cities are connected by Raods ");

String fileInput = "//users//syedqadri/Documents/dev/TreeStructureRoads/InputData001.txt";
List<Line> lines = FileContextReader.ReadFile(fileInput);
Console.WriteLine($"There are about {lines.Count} connected cities");

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
     Console.WriteLine($"From Data {fromData}");
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

          Console.WriteLine($"City Connected {fromData} =====  {toData}");
           city.roadsConnectedTo = 1;
    
                     
      }
      else if(cities.Any(p=>p.CityValue == fromData) )
      {
         var selectedCity = cities.First(p=>p.CityValue == fromData);
         
        // check conneted cities exist
        if(selectedCity.ConnectedCities != null)
        {
           if(cities.Any(p=>p.CityValue != toData) && !selectedCity.ConnectedCities.Any(p=>p.CityValue == toData))
           {
              var lastConnection = selectedCity.ConnectedCities[selectedCity.ConnectedCities.Count-1].CityValue;
              var conCity = new City();
              conCity.CityValue = toData;
              selectedCity.ConnectedCities.Add(conCity);
              Console.WriteLine($"City Connected {fromData} ===== {lastConnection} ===  {toData}");
              Console.WriteLine($"City conneted to {selectedCity.ConnectedCities.Count} cities");
               
           }
           else 
           {  
              Console.WriteLine($"The connected city {fromData} to {toData} already exist ");
           }
           selectedCity.roadsConnectedTo = selectedCity.roadsConnectedTo + 1;
        }
        else 
        {
           // have to add it
              selectedCity.ConnectedCities = new List<City>();
               var conCity = new City();
              conCity.CityValue = toData;
              selectedCity.ConnectedCities.Add(conCity);
      
        }
      }
      
      else if(cities.Any(p=>p.CityValue == toData) )
      {
         var selectedCityOne = cities.First(p=>p.CityValue == toData);
        // check conneted cities exist
        if(selectedCityOne.ConnectedCities != null)
        {
           if( cities.Any(p=>p.CityValue != fromData) && !selectedCityOne.ConnectedCities.Any(p=>p.CityValue == fromData))
           {
               var lastConnection = selectedCityOne.ConnectedCities[selectedCityOne.ConnectedCities.Count-1].CityValue;
             
              var conCity = new City();
              conCity.CityValue = fromData;
              selectedCityOne.ConnectedCities.Add(conCity);
              Console.WriteLine($"City Connected {lastConnection} =====  {toData} === {fromData}");
              selectedCityOne.roadsConnectedTo = selectedCityOne.roadsConnectedTo + 1;
           }
           else 
           {  
              Console.WriteLine($"Cant The connected city {toData} to {fromData} already exist ");
           }

        }
        else 
        {
               selectedCityOne.ConnectedCities = new List<City>();
               var conCity = new City();
               conCity.CityValue = toData;
               selectedCityOne.ConnectedCities.Add(conCity);
      
        }
        
       }
      }
    
    return cities;

  }
 }


