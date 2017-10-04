# WeatherData AzureFunction
Azure function app to retrieve weather data. Created using Visual Studio 2017 in C# and Azure Functions and Web Jobs Tools extension.

This function app is hosted on Azure and can be accessed at the url - https://weatherdatasvc.azurewebsites.net/api/WeatherDataService?location=Chicago&code=R7EHeMJGrdEOtyLPeDy1IVqjN3tdNBrkrZoKhRBwTsZvanuhq/92WA==

In the above url 'location' query string parameter value needs to be changed to a desired location to get the current weather data for that location. For the above api request the JSON result would look as below -

<code>
{"location":{"name":"Chicago","region":"Illinois","country":"United States of America","lat":41.85,"lon":-87.65,"tz_id":"America/Chicago","localtime_epoch":1507133769,"localtime":"2017-10-04 11:16"},"current":{"last_updated_epoch":1507132810,"last_updated":"2017-10-04 11:00","temp_c":21.7,"temp_f":71.1,"is_day":1,"condition":{"text":"Light rain","icon":"//cdn.apixu.com/weather/64x64/day/296.png","code":1183},"wind_mph":10.5,"wind_kph":16.9,"wind_degree":260,"wind_dir":"W","pressure_mb":1026.0,"pressure_in":30.8,"precip_mm":0.0,"precip_in":0.0,"humidity":93,"cloud":100,"feelslike_c":21.7,"feelslike_f":71.1,"vis_km":8.0,"vis_miles":4.0}}
</code>

