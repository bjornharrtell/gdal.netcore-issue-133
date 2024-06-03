FROM ubuntu:22.04
RUN apt-get update
RUN apt install -y curl dotnet8 gdal-bin
RUN curl https://packages.microsoft.com/keys/microsoft.asc | tee /etc/apt/trusted.gpg.d/microsoft.asc
RUN curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list | tee /etc/apt/sources.list.d/mssql-release.list
RUN apt-get update
RUN ACCEPT_EULA=Y apt-get install -y msodbcsql17 unixodbc-dev mssql-tools
WORKDIR /app
COPY . .
RUN dotnet build
CMD ogrinfo "MSSQL:server=localhost;database=TestDB;uid=sa;pwd=YourStrong@Passw0rd;driver={ODBC Driver 17 for SQL Server}"
#dotnet run