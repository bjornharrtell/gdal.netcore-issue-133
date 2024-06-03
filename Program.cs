// See https://aka.ms/new-console-template for more information
using MaxRev.Gdal.Core;
using OSGeo.GDAL;
using OSGeo.OGR;

Console.WriteLine("Hello, World!");

GdalBase.ConfigureAll();

Console.WriteLine("OGR Vector Drivers: {0}", Ogr.GetDriverCount());

 var driverList = string.Join(',', Enumerable.Range(0, Gdal.GetDriverCount())
                    .Select(i => Gdal.GetDriver(i).ShortName)
                    .OrderBy(x => x)
                    .Select(x => $"\"{x}\""));
                Console.WriteLine(driverList);

var ogrPath = $"MSSQL:server=localhost;database=TestDB;uid=sa;pwd=YourStrong@Passw0rd;driver={{ODBC Driver 17 for SQL Server}}";
var ogrSource = Ogr.Open(ogrPath, 0);
